using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;

namespace instrumentssbc.src.ItemTypes
{
    internal class PrecussionMallet : Item
    {
        public override string GetHeldTpHitAnimation(ItemSlot slot, Entity byEntity)
        {
            if ((byEntity as EntityPlayer)?.EntitySelection != null)
            {
                return "hammerhit";
            }

            return base.GetHeldTpHitAnimation(slot, byEntity);
        }
        public override void OnHeldAttackStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, ref EnumHandHandling handling)
        {
            if (blockSel == null)
            {
                base.OnHeldAttackStart(slot, byEntity, blockSel, entitySel, ref handling);
            }
            else if ((byEntity as EntityPlayer)?.Player != null)
            {
                if (!(byEntity.World.BlockAccessor.GetBlock(blockSel.Position) is BlockAnvil))
                {
                    base.OnHeldAttackStart(slot, byEntity, blockSel, entitySel, ref handling);
                }
                else
                {
                    handling = EnumHandHandling.PreventDefault;
                }
            }
        }
        public override void OnHeldActionAnimStart(ItemSlot slot, EntityAgent byEntity, EnumHandInteract type)
        {
            EntityPlayer obj = byEntity as EntityPlayer;
            IPlayer player = obj.Player;
            BlockSelection blockSelection = obj.BlockSelection;
            if (type != EnumHandInteract.HeldItemAttack || blockSelection == null)
            {
                return;
            }

            BlockEntity blockEntity = byEntity.World.BlockAccessor.GetBlockEntity(blockSelection.Position);
            if (byEntity.World.BlockAccessor.GetBlock(blockSelection.Position) is BlockAnvil && blockEntity is BlockEntityAnvil blockEntityAnvil)
            {
                //blockEntityAnvil.OnBeginUse(player, blockSelection);
                startHitAction(slot, byEntity, merge: false);
            }
        }
        /*
        public override void OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            EntityPlayer obj = byEntity as EntityPlayer;
            IPlayer player = obj.Player;
            BlockSelection blockSelection = obj.BlockSelection;
            if (blockSelection == null)
            {
                return;
            }
            BlockEntity blockEntity = byEntity.World.BlockAccessor.GetBlockEntity(blockSelection.Position);
            if (byEntity.World.BlockAccessor.GetBlock(blockSelection.Position) is BlockAnvil && blockEntity is BlockEntityAnvil blockEntityAnvil)
            {
                //blockEntityAnvil.OnBeginUse(player, blockSelection);
                float soundAtFrame = CollectibleBehaviorAnimationAuthoritative.getSoundAtFrame(byEntity, "hammerhit");
                byEntity.AnimManager.RegisterFrameCallback(new AnimFrameCallback
                {
                    Animation = "hammerhit",
                    Frame = soundAtFrame,
                    Callback = delegate
                    {
                        strikeAnvilSound(byEntity, true, slot.Itemstack);
                    }
                });
                handling = EnumHandHandling.PreventDefault;
            }
        }
        */
        private void startHitAction(ItemSlot slot, EntityAgent byEntity, bool merge)
        {
            string heldTpHitAnimation = GetHeldTpHitAnimation(slot, byEntity);
            float soundAtFrame = CollectibleBehaviorAnimationAuthoritative.getSoundAtFrame(byEntity, heldTpHitAnimation);
            float hitDamageAtFrame = CollectibleBehaviorAnimationAuthoritative.getHitDamageAtFrame(byEntity, heldTpHitAnimation);
           
            byEntity.AnimManager.GetAnimationState(heldTpHitAnimation);
            byEntity.AnimManager.RegisterFrameCallback(new AnimFrameCallback
            {
                Animation = heldTpHitAnimation,
                Frame = soundAtFrame,
                Callback = delegate
                {
                    strikeAnvilSound(byEntity, merge, slot.Itemstack);
                }
            });
        }
        protected virtual void strikeAnvilSound(EntityAgent byEntity, bool merge, ItemStack strikingItem)
        {
            IPlayer player = (byEntity as EntityPlayer).Player;
            if (player != null && player.CurrentBlockSelection != null && strikingItem == player.InventoryManager.ActiveHotbarSlot.Itemstack)
            {
                player.Entity.World.PlaySoundAt(merge ? new AssetLocation("sounds/effect/anvilmergehit") : new AssetLocation("sounds/effect/anvilhit"), player.Entity, player, 0.9f + (float)byEntity.World.Rand.NextDouble() * 0.2f, 16f, 0.35f);
            }
        }
    }
}

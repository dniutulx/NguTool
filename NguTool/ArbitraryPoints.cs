
using NguTool.Extensions;

namespace NguTool
{
    class ArbitraryPoints
    {
        public void BuyNewbiePack2(ref PlayerData character)
        {
            //SteamManager.consumeAscendedNewbiePurchase2()

            character.addAP(700000);
            character.arbitrary.energyPotion1Count += 4;
            character.arbitrary.energyPotion2Count += 4;
            character.arbitrary.energyPotion3Count += 4;
            character.arbitrary.magicPotion1Count += 4;
            character.arbitrary.magicPotion2Count += 4;
            character.arbitrary.magicPotion3Count += 4;
            character.arbitrary.lootCharm1Count += 4;
            character.arbitrary.energyBarBar1Count += 4;
            character.arbitrary.magicBarBar1Count += 4;
            character.arbitrary.poop1Count += 50;
            character.arbitrary.lootCharm2Count += 4;
            character.arbitrary.macGuffinBooster1Count += 4;
            character.arbitrary.beastButterCount += 4;

            character.arbitrary.curArbitraryPoints += 225000L; //orange heart

            character.arbitrary.curArbitraryPoints += 250000L; //faster questing

            character.inventory.unlockedKittyArt[3] = true;
            character.arbitrary.boughtAscendedNewbiePack2 = true;
        }

        public void BuyNewbiePack3(ref PlayerData character)
        {
            //SteamManager.consumeAscendedNewbiePurchase3()

            character.addAP(500000);
            character.arbitrary.energyPotion1Count += 4;
            character.arbitrary.energyPotion2Count += 4;
            character.arbitrary.energyPotion3Count += 4;
            character.arbitrary.magicPotion1Count += 4;
            character.arbitrary.magicPotion2Count += 4;
            character.arbitrary.magicPotion3Count += 4;
            character.arbitrary.res3Potion1Count += 4;
            character.arbitrary.res3Potion2Count += 4;
            character.arbitrary.res3Potion3Count += 4;
            character.arbitrary.lootCharm1Count += 4;
            character.arbitrary.energyBarBar1Count += 4;
            character.arbitrary.magicBarBar1Count += 4;
            character.arbitrary.poop1Count += 50;
            character.adventure.itopod.buffedKills += 4000L;
            character.arbitrary.lootCharm2Count += 4;
            character.arbitrary.macGuffinBooster1Count += 4;
            character.arbitrary.beastButterCount += 4;

            character.arbitrary.curArbitraryPoints += 225000L; //blue heart

            character.arbitrary.curArbitraryPoints += 250000L; //faster wishes

            character.arbitrary.boughtAscendedNewbiePack3 = true;
        }
        public void BuyNewbiePack4(ref PlayerData character)
        {
            //SteamManager.consumeAscendedNewbiePurchase4()
            character.addAP(300000);
            character.arbitrary.energyPotion1Count += 4;
            character.arbitrary.energyPotion2Count += 4;
            character.arbitrary.energyPotion3Count += 4;
            character.arbitrary.magicPotion1Count += 4;
            character.arbitrary.magicPotion2Count += 4;
            character.arbitrary.magicPotion3Count += 4;
            character.arbitrary.res3Potion1Count += 4;
            character.arbitrary.res3Potion2Count += 4;
            character.arbitrary.res3Potion3Count += 4;
            character.arbitrary.lootCharm1Count += 4;
            character.arbitrary.energyBarBar1Count += 4;
            character.arbitrary.magicBarBar1Count += 4;
            character.arbitrary.poop1Count += 50;
            character.adventure.itopod.buffedKills += 4000L;
            character.arbitrary.lootCharm2Count += 4;
            character.arbitrary.macGuffinBooster1Count += 4;
            character.arbitrary.beastButterCount += 4;
            character.arbitrary.mayoSpeedPotCount += 4;
            character.arbitrary.cardTierUpperCount += 100;

            character.arbitrary.curArbitraryPoints += 500000L; //rainbow heart

            if (!character.arbitrary.boughtFoils)
            {
                character.arbitrary.boughtFoils = true;
            }
            else
            {
                character.arbitrary.curArbitraryPoints += 250000L;
            }
            character.arbitrary.boughtAscendedNewbiePack4 = true;
        }

        public void BuyAP(ref PlayerData character, int howmuch = 1000000)
        {
            character.addAP(howmuch);
        }

        public void sellConsumables(ref PlayerData character)
        {
            //energy potions
            character.arbitrary.curArbitraryPoints += (character.arbitrary.energyPotion1Count * 5000);
            character.arbitrary.energyPotion1Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.energyPotion2Count * 10000);
            character.arbitrary.energyPotion2Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.energyPotion3Count * 100000);
            character.arbitrary.energyPotion3Count = 0;

            //magic potions
            character.arbitrary.curArbitraryPoints += (character.arbitrary.magicPotion1Count * 5000);
            character.arbitrary.magicPotion1Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.magicPotion2Count * 10000);
            character.arbitrary.magicPotion2Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.magicPotion3Count * 100000);
            character.arbitrary.magicPotion3Count = 0;

            //r3 pots
            character.arbitrary.curArbitraryPoints += (character.arbitrary.res3Potion1Count * 4000);
            character.arbitrary.res3Potion1Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.res3Potion2Count * 40000);
            character.arbitrary.res3Potion2Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.res3Potion3Count * 40000);
            character.arbitrary.res3Potion3Count = 0;

            //bar bars
            character.arbitrary.curArbitraryPoints += (character.arbitrary.energyBarBar1Count * 10000);
            character.arbitrary.energyBarBar1Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.magicBarBar1Count * 10000);
            character.arbitrary.magicBarBar1Count = 0;

            //misc
            character.arbitrary.curArbitraryPoints += (character.arbitrary.macGuffinBooster1Count * 40000);
            character.arbitrary.macGuffinBooster1Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.lootCharm1Count * 5000);
            character.arbitrary.lootCharm1Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.lootCharm2Count * 50000);
            character.arbitrary.lootCharm2Count = 0;

            character.arbitrary.curArbitraryPoints += (character.arbitrary.mayoSpeedPotCount * 40000);
            character.arbitrary.mayoSpeedPotCount = 0;

        }
    }
}

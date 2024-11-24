using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel : MonoBehaviour
{
    [Header("ShopItems")]
    public static List<ShopItemInformation> shopItems = new List<ShopItemInformation>()
    {
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 1,
                        quantityAddBaff = 3,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 2,
                        quantityAddBaff = 2,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 3,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 4,
                        quantityAddBaff = 1,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 5,
                        quantityAddBaff = 4,
                    }
                },
                costPurchase = 999
            },
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 3,
                        quantityAddBaff = 2,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 5,
                        quantityAddBaff = 1,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 1,
                        quantityAddBaff = 2,
                    }
                },
                costPurchase = 1099
            },
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 2,
                        quantityAddBaff = 2,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 5,
                        quantityAddBaff = 2,
                    }
                },
                costPurchase = 1199
            },
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 3,
                        quantityAddBaff = 2,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 2,
                        quantityAddBaff = 2,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 1,
                        quantityAddBaff = 3,
                    }
                },
                costPurchase = 1249
            },
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 1,
                        quantityAddBaff = 2,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 2,
                        quantityAddBaff = 6,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 3,
                        quantityAddBaff = 1,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 4,
                        quantityAddBaff = 1,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 5,
                        quantityAddBaff = 2,
                    }
                },
                costPurchase = 1299
            },
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 2,
                        quantityAddBaff = 4,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 5,
                        quantityAddBaff = 1,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 3,
                        quantityAddBaff = 3,
                    }
                },
                costPurchase = 1999
            },
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 1,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 2,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 3,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 4,
                        quantityAddBaff = 5,
                    }
                },
                costPurchase = 9999
            },
            new ShopItemInformation()
            {
                typeRewardToBuyEnum = TypeReward.Baff,
                informationForBuyBaffs = new List<BaffBuyInformation>()
                {
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 1,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 2,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 3,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 4,
                        quantityAddBaff = 5,
                    },
                    new BaffBuyInformation()
                    {
                        numberAddBaff = 5,
                        quantityAddBaff = 5,
                    }
                },
                costPurchase = 10999
            }
        };
}

[Serializable]
public class ShopItemInformation
{
    [Header("Type Reward")]
    public TypeReward typeRewardToBuyEnum;

    [Header("Quantity Currency For Add Currency Or Baff")]
    public int quantityAddCurrency = 1;
    public List<BaffBuyInformation> informationForBuyBaffs = new List<BaffBuyInformation>();

    [Header("Price/Cost")]
    public int costPurchase;
}

[Serializable]
public class BaffBuyInformation
{
    [Header("Number Baff For Add Baff, Range(1, 5)")]
    public int numberAddBaff = 1;
    public int quantityAddBaff = 1;
}
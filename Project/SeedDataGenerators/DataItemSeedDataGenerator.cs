using Project.DbContexts;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Project.UnitTests")]
namespace Project.SeedDataGenerators
{
    public static class DataItemSeedDataGenerator
    {
        public static void GenerateDataItemSeedData(DataItemContext context)
        {
            var dataItemSeedData = GetSeedData();
            context.DataItems.AddRange(dataItemSeedData);
            context.SaveChanges();
        }

        internal static IEnumerable<DataItem> GetSeedData()
        {
            var stringMultipleOf3 = "Fizz";
            var stringMultipleOf5 = "Buzz";
            var dataItemList = new List<DataItem>();
            for (int i = 1; i <= 100; i++)
            {
                var dataItem = GetValueStringByNumber(stringMultipleOf3, stringMultipleOf5, i);

                dataItemList.Add(dataItem);
            }
            return dataItemList;
        }

        internal static DataItem GetValueStringByNumber(string stringMultipleOf3, string stringMultipleOf5, int i)
        {
            if (i <= 0)
            {
                throw new ArgumentException("i is 0 or less than 0");
            }
            var dataItemValue = i.ToString();
            // i is a multiple of both 3 and 5
            if (i % 15 == 0)
            {
                dataItemValue = stringMultipleOf3 + stringMultipleOf5;
            }
            // i is a multiple of 3
            else if (i % 3 == 0)
            {
                dataItemValue = stringMultipleOf3;
            }
            // i is a multiple of 5
            else if (i % 5 == 0)
            {
                dataItemValue = stringMultipleOf5;
            }

            var dataItem = new DataItem() { Value = dataItemValue };
            return dataItem;
        }
    }
}

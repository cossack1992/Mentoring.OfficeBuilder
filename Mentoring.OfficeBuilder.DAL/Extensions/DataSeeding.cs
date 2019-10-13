using Mentoring.OfficeBuilder.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.Extensions
{
    public static class DataSeeding
    {
        private static string style = @"style='fill:white;stroke:black;stroke-width:3'";

        public static void ApplyDefaultData(this OfficeDbContext context)
        {
            if (context.DbAreas.Any())
            {
                return;
            }

            DbItemModel itemModel1 = new DbItemModel
            {
                Svg = $@"<rect width='10' height='10' x='20' y='50' {style}/>",
            };
            DbItemModel itemModel2 = new DbItemModel
            {
                Svg = $@"<rect width='10' height='10' x='50' y='20' {style}/>"
            };
            var area1 = new DbAreaModel
            {
                Items = new List<DbItemModel>(),
                MovedFromItems = new List<DbItemModel>(),
                X = 0,
                Y = 0,
                Name = "Main",
                Width = 100,
                Height = 100
            }.AddItem(itemModel1).AddItem(itemModel2);


            DbItemModel itemModel3 = new DbItemModel
            {
                Svg = $@"<rect width='10' height='10' x='50' y='40' {style}/>"
            };
            DbItemModel itemModel4 = new DbItemModel
            {
                Svg = $@"<rect width='10' height='10' x='50' y='80' {style}/>"
            };
            var area2 = new DbAreaModel
            {
                Items = new List<DbItemModel>(),
                MovedFromItems = new List<DbItemModel>(),
                X = 0,
                Y = 0,
                Name = "Main",
                Width = 100,
                Height = 100
            }.AddItem(itemModel3).AddItem(itemModel4);

            DbItemModel itemModel5 = new DbItemModel
            {
                Svg = $@"<rect width='10' height='10' x='70' y='20' {style}/>"
            };
            var area3 = new DbAreaModel
            {
                Items = new List<DbItemModel>(),
                MovedFromItems = new List<DbItemModel>(),
                X = 0,
                Y = 0,
                Name = "Main",
                Width = 100,
                Height = 100
            }.AddItem(itemModel5);

            itemModel1.AddMoveToArea(area1);
            itemModel2.AddMoveToArea(area3);
            itemModel3.AddMoveToArea(area2);
            itemModel4.AddMoveToArea(area1);
            itemModel5.AddMoveToArea(area3);

            context.DbAreas.AddRange(
                area1,
                area2,
                area3);

            context.SaveChanges();
        }
    }
}

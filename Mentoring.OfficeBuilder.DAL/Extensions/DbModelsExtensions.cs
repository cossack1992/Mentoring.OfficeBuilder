using Mentoring.OfficeBuilder.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.Extensions
{
    public static class DbModelsExtensions
    {
        public static DbAreaModel AddItem(this DbAreaModel areaModel, DbItemModel itemModel)
        {
            itemModel.Area = areaModel;
            areaModel.Items.Add(itemModel);

            return areaModel;
        }

        public static DbItemModel AddMoveToArea(this DbItemModel itemModel, DbAreaModel areaModel)
        {
            itemModel.MoveToArea = areaModel;
            areaModel.MovedFromItems.Add(itemModel);

            return itemModel;
        }
    }
}

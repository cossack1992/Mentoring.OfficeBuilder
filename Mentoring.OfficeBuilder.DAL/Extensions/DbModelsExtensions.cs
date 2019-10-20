using Mentoring.OfficeBuilder.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.Extensions
{
    public static class DbModelsExtensions
    {
        public static DbGroupModel AddItem(this DbGroupModel groupModel, DbItemModel itemModel)
        {
            itemModel.Group = groupModel;
            groupModel.Items.Add(itemModel);

            return groupModel;
        }

        public static DbItemModel AddMoveToArea(this DbItemModel itemModel, DbAreaModel areaModel)
        {
            itemModel.MoveToArea = areaModel;
            areaModel.MovedFromItems.Add(itemModel);

            return itemModel;
        }

        public static DbAreaModel AddGroup(this DbAreaModel area, DbGroupModel dbGroupModel)
        {
            dbGroupModel.Area = area;
            area.Groups.Add(dbGroupModel);

            return area;
        }
    }
}

using Mentoring.OfficeBuilder.DAL.DbModels;
using Mentoring.OfficeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.API
{
    public static class DbModelExtensions
    {
        public static OfficeAreaModel GetAreaFromDbModel(this DbAreaModel dbModel)
        {
            var model = new OfficeAreaModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Position = new Position
                {
                    X = dbModel.X,
                    Y = dbModel.Y
                },
                Size = new Size
                {
                    Height = dbModel.Height,
                    Width = dbModel.Width
                },
                Items = dbModel.Items.Select(x => new OfficeItemModel 
                {
                    Id = x.Id,
                    Svg = x.Svg,
                    AreaToMove = x.MoveToArea.Id
                }).ToList()
            };

            return model;
        }
    }
}

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
                Groups = dbModel.Groups.Select(x => new OfficeItemGroup
                {
                    Id = x.Id,
                    Items = x.Items.Select(y => new OfficeItemModel 
                    {
                        Id = y.Id,
                        AreaToMove = y.MoveToArea.Id,
                        Svg = y.Svg
                    }).ToList()
                }).ToList()
            };

            return model;
        }
    }
}

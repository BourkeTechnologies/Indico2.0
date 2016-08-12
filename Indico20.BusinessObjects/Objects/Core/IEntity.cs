﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Indico20.BusinessObjects.Base.Core;

namespace Indico20.BusinessObjects.Objects.Core
{
    public interface IEntity : INotifyPropertyChanged
    {
        int ID { get; }
        Dictionary<string, object> GetColumnValueMapping();

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        IDbContext _Context { get; set; }
    }
}
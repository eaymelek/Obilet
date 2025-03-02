﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /// <summary>
    /// Represents a data result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}

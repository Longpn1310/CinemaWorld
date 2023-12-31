﻿namespace CinemaWorld.Global.Common.Repositories
{
    using System;
    using System.Threading.Tasks;
    public interface IDbQueryRunner : IDisposable
    {
            Task RunQueryAsync(string query, params object[] parameters);
    }
}

﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionProvider.cs" company="saramgsilva">
//   Copyright (c) 2013 saramgsilva. All rights reserved. 
// </copyright>
// <summary>
//   Defines the ISessionProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using HikeMate.UniversalApps.Services.Model;

namespace HikeMate.UniversalApps.Services.Interfaces
{
    /// <summary>
    /// The SessionProvider interface.
    /// </summary>
    public interface ISessionProvider
    {
        /// <summary>
        /// The login sync.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> object.
        /// </returns>
        Task<Session> LoginAsync();

        /// <summary>
        /// The logout.
        /// </summary>
        void Logout();
    }
}

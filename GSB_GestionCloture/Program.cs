// <copyright file="Program.cs" company="Dylan LE FLOUR">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GSB_GestionCloture
{
    using System.Threading;

    /// <summary>
    /// Classe d'exécution de la solution.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main de la classe.
        /// </summary>
        public static void Main()
        {
            GestionTimer timer = new GestionTimer(60000);
            Thread nonFermeture = new Thread(timer.SetTimer);
            nonFermeture.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}

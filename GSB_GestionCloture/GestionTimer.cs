// <copyright file="GestionTimer.cs" company="Dylan LE FLOUR">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GSB_GestionCloture
{
    using System;
    using System.Timers;

    /// <summary>
    /// Classe de gestion du timer.
    /// </summary>
    public class GestionTimer
    {
        private int delaiTimer;
        private Timer timerCloture;

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionTimer"/> class.
        /// Initialise une nouvelle instance de la classe GestionTimer.
        /// </summary>
        /// <param name="delaiTimer">Delai du timer.</param>
        public GestionTimer(int delaiTimer)
        {
            this.delaiTimer = delaiTimer;
            this.timerCloture = new Timer();
        }

        /// <summary>
        /// Paramètre le timer.
        /// </summary>
        public void SetTimer()
        {
            this.timerCloture.AutoReset = true;
            this.timerCloture.Enabled = true;
            this.timerCloture.Interval = this.delaiTimer;
            this.timerCloture.Elapsed += this.OnTimedEvent;
            this.timerCloture.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            GestionFiches.ClotureFiches();
            GestionFiches.RembourseFiches();
        }
    }
}

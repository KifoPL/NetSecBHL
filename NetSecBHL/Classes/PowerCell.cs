using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    /// <summary>
    /// Contains information about current charge of PowerCell
    /// </summary>
    public static class PowerCell
    {
        private static float currentCharge;
        /// <summary>
        /// The maximum capacity of the powercell
        /// </summary>
        public static int MaxCharge = 7;
        /// <summary>
        /// The maximum charging speed of the powercell per hour
        /// </summary>
        public static int MaxChargingSpeed = 1;
        /// <summary>
        /// The maximum usage charge speed of the powercell per hour
        /// </summary>
        public static int MaxUsageCharge = 2;

        public static float CurrentCharge { get => currentCharge; }
        /// <summary>
        /// Adds given charge.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="InvalidOperationException">Throws when too much charge.</exception>
        public static void addCharge(float value)
        {
            if (CurrentCharge + value > MaxCharge) throw new InvalidOperationException(message: "PowerCell: Too much charge!");
            else currentCharge += value;
        }
        /// <summary>
        /// Decreases given charge.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="InvalidOperationException">Throws when charge drops below 0.</exception>
        public static void decreaseCharge(float value)
        {
            if (currentCharge - value >= 0) currentCharge -= value;
            else throw new InvalidOperationException(message: "PowerCell: Charge below 0!");
        }
    }
}

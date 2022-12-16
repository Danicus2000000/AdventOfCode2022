namespace Day_16
{
    internal class valve//A valve type
    {
        internal int mPressureValue;
        internal string? mValveName;
        internal bool mIsTurned;
        internal List<valve> mConnectedValves;
        internal int mPressureReleased;
        internal int mMinuitesLeft;
        internal valve? mParent;
        /// <summary>
        /// Creates a valve using its pressure and name
        /// </summary>
        /// <param name="pPressureValue">The Pressure value of this valve</param>
        /// <param name="pValveName">The Name of this valve</param>
        internal valve(int pPressureValue, string pValveName) 
        {
            mPressureValue = pPressureValue;
            mValveName = pValveName;
            mIsTurned = false;
            mConnectedValves=new List<valve>();
            mPressureReleased= 0;
            mMinuitesLeft = 30;
        }
    }
}

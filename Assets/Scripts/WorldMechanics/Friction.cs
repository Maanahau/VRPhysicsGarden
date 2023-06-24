namespace WorldMechanics
{
    public static class Friction
    {
        /*  
         *  These values represent the max and min individual "realistic" friction value for an object.
         *  You can think of these values as the roughness of a material. 
        */

        public const float minGlobalFriction = 0.01f; //min "realistic" friction value
        public const float maxGlobalFriction = 1.5f;  //max "realistic" friction value

        //normalize realistic friction values on a [0,1] range
        public static float NormalizeValue(float value)
        {
            return (value - minGlobalFriction) / (maxGlobalFriction - minGlobalFriction);
        }
        
        //get realistic friction values from a [0,1] range
        public static float RevertValue(float normalizedValue)
        {
            return normalizedValue * (maxGlobalFriction - minGlobalFriction) + minGlobalFriction;
        }
    }
}


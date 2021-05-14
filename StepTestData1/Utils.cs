using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTestData1
{
    /// <summary>
    /// (The Utils Class may appear a bit messy but I didn't find any solution to handle that in another way)
    /// It stores the two conversion tables (male, female) to get the rating from the score 
    /// and the conversion table to get the aerobic capacity from a level and a step height
    /// </summary>
    public static class Utils
    {

        /// <summary>
        /// Methods that get the Fitness Rating from a all the data in parameter
        /// It find in the male table of female table below the apropriate values
        /// </summary>
        /// <param name="score">The score of the test</param>
        /// <param name="age">The age of the participant</param>
        /// <param name="sex">The sex of the participant</param>
        /// <returns>A rating label from the Rating enum or null if it found nothing</returns>
        public static Rating? ComputeRatingFromScore(int score, int age, Sex sex)
        {
            try
            {
                var table = sex == Sex.Male ? maleTable : femaleTable;
                Bounds ageBound = table.Keys.Single(el => el.Contains(age));
                Bounds scoreBound = table[ageBound].Keys.Single(el => el.Contains(score));
                return table[ageBound][scoreBound];
            } catch
            {
                return null;
            }
        }

        /// <summary>
        /// Methods that get the aerobic capacity in order to place the point correctly when computing results
        /// </summary>
        /// <param name="level">The level of the measure (0 to 4)</param>
        /// <param name="stepHeight">The height of the step</param>
        /// <returns>The aerobic capacity</returns>
        public static int? GetAreobicCapacityFromStep(int level, int stepHeight)
        {
            try
            {
                return stepTable[level][stepHeight];
            } catch
            {
                return null;
            }
        }
        /// <summary>
        /// The List represents all the levels and the key of the dictionnary is the step height, the value is the aerobic capacity
        /// </summary>
        public static readonly List<Dictionary<int, int>> stepTable = new List<Dictionary<int, int>>
        {
            new Dictionary<int, int>
            {
                { 15, 11 },
                { 20, 12 },
                { 25, 14 },
                { 30, 16 }
            },
            new Dictionary<int, int>
            {
                { 15, 14 },
                { 20, 17 },
                { 25, 19 },
                { 30, 21 },
            },
            new Dictionary<int, int>
            {
                { 15, 18 },
                { 20, 21 },
                { 25, 24 },
                { 30, 27 }
            },
            new Dictionary<int, int>
            {
                { 15, 21 },
                { 20, 25 },
                { 25, 28 },
                { 30, 32 }
            },
            new Dictionary<int, int>
            {
                { 15, 25 },
                { 20, 29 },
                { 25, 33 },
                { 30, 37 }
            }
        };
        /// <summary>
        /// The key of the first dictionnary is a bound representing the min age and the max age, 
        /// the value is another dictionnary with the score as key and the rating as value
        /// </summary>
        public static readonly Dictionary<Bounds, Dictionary<Bounds, Rating>> femaleTable = new Dictionary<Bounds, Dictionary<Bounds, Rating>>()
        {
            {
                new Bounds(15, 19), new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(55, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(44, 54),
                        Rating.Good
                    },
                    {
                        new Bounds(36, 43),
                        Rating.Average
                    },
                    {
                        new Bounds(29, 35),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 29),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(20, 29),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(50, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(40, 49),
                        Rating.Good
                    },
                    {
                        new Bounds(32, 39),
                        Rating.Average
                    },
                    {
                        new Bounds(27, 31),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 27),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(30, 39),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(46, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(36, 45),
                        Rating.Good
                    },
                    {
                        new Bounds(30, 35),
                        Rating.Average
                    },
                    {
                        new Bounds(25, 29),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 25),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(40, 49),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(43, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(34, 42),
                        Rating.Good
                    },
                    {
                        new Bounds(28, 33),
                        Rating.Average
                    },
                    {
                        new Bounds(22, 27),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 22),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(50, 59),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(41, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(33, 40),
                        Rating.Good
                    },
                    {
                        new Bounds(26, 32),
                        Rating.Average
                    },
                    {
                        new Bounds(21, 25),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 21),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(60, 69),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(39, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(31, 38),
                        Rating.Good
                    },
                    {
                        new Bounds(24, 30),
                        Rating.Average
                    },
                    {
                        new Bounds(19, 23),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 19),
                        Rating.Poor
                    }
                }
            }
        };

        public static readonly Dictionary<Bounds, Dictionary<Bounds, Rating>> maleTable = new Dictionary<Bounds, Dictionary<Bounds, Rating>>()
        {
            {
                new Bounds(15, 19), new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(60, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(58, 59),
                        Rating.Good
                    },
                    {
                        new Bounds(39, 47),
                        Rating.Average
                    },
                    {
                        new Bounds(30, 38),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 29),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(20, 29),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(55, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(44, 54),
                        Rating.Good
                    },
                    {
                        new Bounds(35, 43),
                        Rating.Average
                    },
                    {
                        new Bounds(28, 34),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 28),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(30, 39),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(50, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(40, 49),
                        Rating.Good
                    },
                    {
                        new Bounds(34, 39),
                        Rating.Average
                    },
                    {
                        new Bounds(26, 33),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 26),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(40, 49),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(46, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(37, 45),
                        Rating.Good
                    },
                    {
                        new Bounds(32, 36),
                        Rating.Average
                    },
                    {
                        new Bounds(25, 31),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 25),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(50, 59),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(44, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(35, 43),
                        Rating.Good
                    },
                    {
                        new Bounds(29, 34),
                        Rating.Average
                    },
                    {
                        new Bounds(23, 28),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 23),
                        Rating.Poor
                    }
                }
            },
            {
                new Bounds(60, 69),
                new Dictionary<Bounds, Rating>()
                {
                    {
                        new Bounds(40, 76),
                        Rating.Excellent
                    },
                    {
                        new Bounds(33, 39),
                        Rating.Good
                    },
                    {
                        new Bounds(25, 32),
                        Rating.Average
                    },
                    {
                        new Bounds(20, 24),
                        Rating.BelowAverage
                    },
                    {
                        new Bounds(10, 20),
                        Rating.Poor
                    }
                }
            }
        };
    }

    /// <summary>
    /// Class that represent a bound (a min and a max) with a method contains to know if a value is in the bounds
    /// </summary>
    public class Bounds
    {

        public Bounds(int min, int max = int.MaxValue)
        {
            this.min = min;
            this.max = max;
        }

        public bool Contains(int val)
        {
            return val >= min && val <= max;
        }
        public bool Contains(Bounds bound)
        {
            return bound.min >= min && bound.max <= max;
        }
        public override string ToString()
        {
            return "Bounds (" + min + ", " + max + ")";
        }

        public override int GetHashCode()
        {
            return min;
        }

        public int min = 0;
        public int max = 0;
    }


    public enum Rating
    {
        Excellent,
        Good,
        Average,
        BelowAverage,
        Poor,
    }
}

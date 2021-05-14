using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTestData1
{
    public static class Utils
    {

        public static Rating? ComputeRatingFromScore(int score, int age, Sex sex)
        {
            try
            {
                if (sex == Sex.Male)
                {
                    Bounds ageBound = maleTable.Keys.Single(el => el.Contains(age));
                    Bounds scoreBound = maleTable[ageBound].Keys.Single(el => el.Contains(score));
                    return maleTable[ageBound][scoreBound];
                }
                else
                {
                    Bounds ageBound = femaleTable.Keys.Single(el => el.Contains(age));
                    Bounds scoreBound = femaleTable[ageBound].Keys.Single(el => el.Contains(score));
                    return femaleTable[ageBound][scoreBound];
                }
            } catch
            {
                return null;
            }
        }

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

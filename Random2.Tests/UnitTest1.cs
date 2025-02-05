namespace Random.Tests;
using Xunit;
using RandomGenerators;
using System;
using System.Text.RegularExpressions; 


public class UnitTest1
{

// Tests for Normal Distribution Generator
    [Theory]
    [InlineData(50, 10)]
    [InlineData(0, 1)]
    [InlineData(100, 20)]
    [InlineData(-25, 5)]
    public void TestNormalDistribution(double mean, double stdDev)
    {
        int sampleSize = 10000;
        double sum = 0;
        double sumSq = 0;

        for (int i = 0; i < sampleSize; i++)
        {
            double num = RandomFunctions.GenerateNormalRandom(mean, stdDev);
            sum += num;
            sumSq += num * num;
        }

        double sampleMean = sum / sampleSize;
        double sampleStdDev = Math.Sqrt((sumSq / sampleSize) - (sampleMean * sampleMean));

        Assert.InRange(sampleMean, mean - 2, mean + 2);
        Assert.InRange(sampleStdDev, stdDev - 2, stdDev + 2);
    }



    [Fact]
    public void Test1()
    {
        double mean = 0;
        double stdDev = 1000;
        double num = RandomFunctions.GenerateNormalRandom(mean, stdDev);

        Assert.True(num >= mean - 5 * stdDev && num <= mean + 5 * stdDev, 
                    "Value should be within a reasonable range.");
    }


// Tests for Password Generator
    [Theory]
    [InlineData(6)]
    [InlineData(10)]
    [InlineData(20)]
    public void TestPasswordGeneration(int length)
    {
        string password = RandomFunctions.GeneratePassword(length);

        Assert.Equal(length, password.Length);
        Assert.Matches(@"^[A-Za-z0-9_]+$", password);
    }


    // Edge case: Minimum and Maximum Length Passwords
    [Fact]
    public void TestPasswordGenerationMinMaxLength()
    {
        string minPassword = RandomFunctions.GeneratePassword(1);
        string maxPassword = RandomFunctions.GeneratePassword(100);

        Assert.Equal(1, minPassword.Length);
        Assert.Equal(100, maxPassword.Length);
    }


// Tests for Color Generator
    [Fact]
    public void TestColorGeneration()
    {
        var (hex, rgb) = RandomFunctions.GenerateRandomColor();

        Assert.Matches(@"^#[0-9A-Fa-f]{6}$", hex);
        Assert.InRange(rgb.Item1, 0, 255);
        Assert.InRange(rgb.Item2, 0, 255);
        Assert.InRange(rgb.Item3, 0, 255);

        string expectedHex = $"#{rgb.Item1:X2}{rgb.Item2:X2}{rgb.Item3:X2}";
        Assert.Equal(expectedHex, hex);
    }

// Additional test to verify multiple generated colors are different
    [Fact]
    public void TestColorGenerationUniqueness()
    {
        var color1 = RandomFunctions.GenerateRandomColor();
        var color2 = RandomFunctions.GenerateRandomColor();

        Assert.NotEqual(color1, color2);
    }
}

    }
}
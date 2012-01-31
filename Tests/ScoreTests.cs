//***LICENSE:******************************************************************
// Copyright (c) 2012, Adam Caudill <adam@adamcaudill.com>
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met:
// 
// 1). Redistributions of source code must retain the above copyright notice, 
//     this list of conditions and the following disclaimer.
// 
// 2). Redistributions in binary form must reproduce the above copyright 
//     notice, this list of conditions and the following disclaimer in the 
//     documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.
//*****************************************************************************

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ccsrch_score;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class ScoreTests
  {
    [TestClass]
    public class FileTypeTests
    {
      [TestMethod]
      public void ShouldBeMinusThree()
      {
        Assert.AreEqual(-3, Scores.FileTypeScore(string.Empty, "test.bmp"));
      }
    }

    [TestClass]
    public class FileNameTests
    {
      [TestMethod]
      public void ShouldBeMinusThree()
      {
        Assert.AreEqual(-3, Scores.FileNameScore(string.Empty, "index.dat"));
      }

      [TestMethod]
      public void ShouldBeMinusNintyNine()
      {
        Assert.AreEqual(-99, Scores.FileNameScore(string.Empty, "ntuser.dat"));
      }
    }

    [TestClass]
    public class DisctinctDigitTests
    {
      [TestMethod]
      public void ScoreShouldBeNonZero()
      {
        Assert.AreNotEqual(0, Scores.DistinctDigitScore("1234123412341234"));
      }

      [TestMethod]
      public void ScoreShouldBeOne()
      {
        Assert.AreEqual(1, Scores.DistinctDigitScore("1111111111111111"));
      }

      [TestMethod]
      public void ScoreShouldBeTwo()
      {
        Assert.AreEqual(2, Scores.DistinctDigitScore("1234123412341234"));
      }

      [TestMethod]
      public void ScoreShouldBeFive()
      {
        Assert.AreEqual(5, Scores.DistinctDigitScore("9876543210123456"));
      }
    }

    [TestClass]
    public class CommonFalsePositivesTests
    {
      [TestMethod]
      public void ShouldBeMinusNintyNine()
      {
        Assert.AreEqual(-99, Scores.CommonFalsePositiveScore("344455566677788"));
      }
    }

    [TestClass]
    public class KnownBinScoreTests
    {
      [TestMethod]
      public void ShouldBeTrue()
      {
        Assert.AreEqual(true, Scores.IsKnownBin("1234123412341234", new List<string>() { "123412" }));
      }
    }
  }
}

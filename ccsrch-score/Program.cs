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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ccsrch_score
{
  public class Program
  {
    static void Main(string[] args)
    {
      if (args.Count() >= 1 && File.Exists(args[0]))
      {
        var file = args[0];
        var min = 0;
        var reader = new StreamReader(file);
        var writer = new StreamWriter(Parser.GetOutputName(file));
        string line;
        var count = 0;

        if (args.Count() >= 2)
          int.TryParse(args[1], out min);

        while ((line = reader.ReadLine()) != null)
        {
          var card = Parser.GetCardNumber(line);
          var target = Parser.GetFileName(line);

          if (card != null)
          {
            var score = _ScoreHit(card, target);
            line = string.Format("{0}\t{1}", line, score);

            if (score < min)
              line = null;
          }

          if (!string.IsNullOrEmpty(line))
            writer.WriteLine(line);

          count++;

          if (count % 5000 == 0)
            Console.WriteLine("Completed: " + count);
        }

        writer.Close();
        reader.Close();
      }
      else
      {
        Console.WriteLine("File not found: " + args[0]);
      }
    }

    private static int _ScoreHit(string hit, string path)
    {
      var score = 0;

      score += Scores.DistinctDigitScore(hit);
      score += Scores.CommonFalsePositiveScore(hit);
      score += Scores.FileTypeScore(hit, path);
      score += Scores.FileNameScore(hit, path);

      return Math.Min(Math.Max(score, 0), 9);
    }
  }
}

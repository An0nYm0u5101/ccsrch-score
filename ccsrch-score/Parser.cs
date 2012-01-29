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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ccsrch_score
{
  public static class Parser
  {
    public static string GetCardNumber(string line)
    {
      string ret = null;
      var split = line.Split('\t');
      if (split.Count() >= 3)
      {
        //this could be a result line, let's see if the 3rd item is a number
        var number = split[2];

        if (_IsNumber(number))
          ret = number;
      }

      return ret;
    }

    public static string GetOutputName(string input)
    {
      var baseName = Path.GetFileNameWithoutExtension(input);
      var ext = Path.GetExtension(input);
      var dir = Path.GetDirectoryName(input);

      return Path.Combine(dir, string.Format("{0}_scored{1}", baseName, ext));
    }

    private static bool _IsNumber(string text)
    {
      var regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
      return regex.IsMatch(text);
    }
  }
}

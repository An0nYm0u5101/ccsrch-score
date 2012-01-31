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

namespace ccsrch_score
{
  public static class Scores
  {
    /// <summary>
    /// Returns the number of distinct digits, devided by 2. Minimum value is 1.
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    public static int DistinctDigitScore(string hit)
    {
      var count = hit.ToCharArray().Distinct().Count();

      return Math.Max((int)Math.Ceiling(count/2D), 1);
    }

    public static int CommonFalsePositiveScore(string hit)
    {
      var ret = 0;

      if (hit == "344455566677788")
        ret = -99;

      return ret;
    }

    public static int FileTypeScore(string hit, string path)
    {
      var ext = Path.GetExtension(path);
      var ret = 0;

      switch (ext)
      {
        case ".rtf":
        case ".pdf":
          ret = -3;
          break;
        case ".pdb":
        case ".dll":
        case ".exe":
        case ".png":
        case ".gif":
        case ".jpg":
        case ".jpeg":
        case ".bmp":
        case ".psd":
        case ".dng":
        case ".nef":
        case ".wmv":
        case ".mov":
        case ".jar":
        case ".cab":
        case ".msi":
        case ".zip":
        case ".manifest":
          ret = -99;
          break;
      }

      return ret;
    }

    public static int FileNameScore(string hit, string path)
    {
      var fileName = Path.GetFileName(path);
      var ret = 0;

      switch (fileName.ToLower())
      {
        case "ntuser.dat":
        case "iconcache.db":
          ret = -99;
          break;
        case "index.dat":
          ret = -3;
          break;
      }

      return ret;
    }
  }
}

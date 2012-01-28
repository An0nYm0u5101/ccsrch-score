# ccsrch-score

ccsrch-score is a small CLI application to apply scoring to result files generate by the [ccsrch](https://github.com/adamcaudill/ccsrch) application.

## How do I use it?

`ccsrch-score.exe <output.txt>`

Where `<output.txt>` is the name of the file you passed to the `-o` parameter of `ccsrch`. If your output file is called `output.txt` - a file called `output_scored.txt` will be created that contains the original content, plus a number (0 to 9) to indicate the likelyhood that it's a real credit card number.

## How does it work?

_Details coming soon..._

## ccsrch is cross platform, why isn't this?

`ccsrch` was written in C to be cross platform, which makes a lot of sense as production environments are rarely homogeneous - from Windows-based file servers to *nix-based database servers. On the other hand, `ccsrch-score` isn't intended to be ran in the production environment, but is instead meant to be used as an analysis tool once scans are completed.

## License

`ccsrch-score` is licensed under the [BSD 2-clause](http://www.opensource.org/licenses/bsd-license.php) license.
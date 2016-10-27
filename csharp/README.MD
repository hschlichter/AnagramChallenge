# C#


The application is split up into 3 parts. Each responsible for its own area.

- Program
- Library
- Tests

To run the application execute the following commands.

```sh
# Execute these commands from the root application folder.

$ dotnet restore

$ dotnet test Tests

$ dotnet run -c Release -p Program "poultry outwits ants" 4624d200580677270a54ccff86b9610e

```

A different way of running the application would be to invoke the dll directly.

```sh
$ dotnet Program/bin/Release/netcoreapp1.0/Program.dll "poultry outwits ants" 4624d200580677270a54ccff86b9610e
```

As of the current implementation, this is an example of the output from running the application.

```sh
$ time dotnet run -c Release -p Program "poultry outwits ants" 4624d200580677270a54ccff86b9610e
Project Lib (.NETStandard,Version=v1.6) will be compiled because inputs were modified
Compiling Lib for .NETStandard,Version=v1.6

Compilation succeeded.
    0 Warning(s)
    0 Error(s)

Time elapsed 00:00:01.1128520
Project Program (.NETCoreApp,Version=v1.0) will be compiled because dependencies changed
Compiling Program for .NETCoreApp,Version=v1.0

Compilation succeeded.
    0 Warning(s)
    0 Error(s)

Time elapsed 00:00:00.9595221


Number of words in wordlist: 99174
Unique characters in sentence: 12
wordlist size after filtering on unique character: 2683
wordlist size after filtering on length: 2046
Batch done - 88 - First: alots outputs wintry - Last: intrusts typo outlaw
Batch done - 660 - First: nulity outpost straw - Last: pitons trusty outlaw
Batch done - 102 - First: rosalyn output twist - Last: snowy starlit output
Batch done - 290 - First: plaits towy turnouts - Last: raly untwist outpost
Batch done - 98 - First: larson output twisty - Last: notary wilts outputs
Batch done - 316 - First: sort outplay untwist - Last: suton partly outwits
Batch done - 878 - First: tunas outwits portly - Last: yups untwist tortola
Batch done - 652 - First: swat polity turnouts - Last: tulsa wintry outpost
Permutations count: 3084
Found match!! - pastils turnout towy
Done!

real	1m18.320s
user	5m47.831s
sys	0m2.544s
```
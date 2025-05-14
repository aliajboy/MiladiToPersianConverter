# MiladiToPersianConverter

![NuGet](https://img.shields.io/nuget/v/MiladiToPersianConverter.svg)

A comprehensive .NET library for converting between Gregorian (Miladi) and Persian (Shamsi/Jalali) calendar dates with extensive formatting options.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
  - [Basic Conversion](#basic-conversion)
  - [Formatting Helpers](#formatting-helpers)
  - [Reverse Conversion](#reverse-conversion)
  - [Utility Methods](#utility-methods)
- [Code Examples](#code-examples)
- [Support](#support)

## Features

- ⏳ Bidirectional conversion between Gregorian and Persian calendars
- 🎨 Multiple formatting options:
  - Compact date strings (`YYYYMMDD`)
  - Datetime with hours and minutes (`YYYYMMDDHHmm`)
  - Full datetime with seconds (`YYYYMMDDHHmmss`)
  - Human-readable formats with Persian month names
- 🔧 Utility methods for:
  - Adding separators (slashes/dashes) to dates
  - Formatting time strings
  - Getting Persian day/month names
  - Unix timestamp conversion
- 🛡️ Error handling with fallback to current datetime

## Installation

### NuGet Package Manager
```
Install-Package MiladiToPersianConverter
```

### Package Reference
```
<PackageReference Include="MiladiToPersianConverter" Version="1.0.0" />
```

## Usage
### Basic Conversion
```
using MiladiToPersianConverter;

// Convert current date to Persian
DateTime now = DateTime.Now;
string persianDate = now.MiladiToPersian(); // "14020225"
string persianWithTime = now.MiladiToPersianWithMinutes(); // "140202251430"
string persianFull = now.MiladiToPersianWithSeconds(); // "14020225143015"
string withMonthName = now.MiladiToPersianWithMonthName(); // "25 اردیبهشت 1402"
```
### Formatting Helpers
```
// Format date strings
string withSlashes = "14020225".SetDateSlash(); // "1402/02/25"
string withDashes = "14020225".SetDateDash();   // "1402-02-25"

// Format time strings
string formattedTime = "1425".SetTimeSeparate(); // "14:25"
string fullTime = "142533".SetTimeSeparate();    // "14:25:33"

// Combined datetime formatting
string formattedDT = "140202251430".SetDateTimeSeprator(); // "14:30 - 1402/02/25"
```
### Reverse Conversion
```
// Persian to Gregorian conversion
DateTime fromPersianDate = "14020225".PersianToMiladi();
DateTime fromPersianDateTime = "140202251430".PersianToMiladiDateTime();
```
### Utility Methods
```
// Get Persian names
string dayName = DayOfWeek.Friday.GetPersianDayOfWeek(); // "جمعه"
string monthName = 7.GetPersianMounth(); // "مهر"

// Unix timestamp
double unixTime = DateTime.Now.ToUnixTimeStamp(3.5); // Tehran timezone
```
## Code Examples
### Complete Conversion Example
```
using System;
using MiladiToPersianConverter;

class Program
{
    static void Main()
    {
        // Gregorian to Persian
        DateTime gregorianDate = new DateTime(2023, 5, 15, 14, 30, 0);
        
        Console.WriteLine(gregorianDate.MiladiToPersian()); // "14020225"
        Console.WriteLine(gregorianDate.MiladiToPersianWithMonthName()); // "25 اردیبهشت 1402"
        
        // Persian to Gregorian
        DateTime convertedBack = "14020225".PersianToMiladi();
        Console.WriteLine(convertedBack.ToString("yyyy-MM-dd")); // "2023-05-15"
        
        // Formatting
        Console.WriteLine("140202251430".SetDateTimeSeprator()); // "14:30 - 1402/02/25"
    }
}
```
### Error Handling Example
```
try
{
    DateTime invalidConversion = "invalid".PersianToMiladi();
}
catch
{
    // Falls back to DateTime.Now
    Console.WriteLine("Conversion failed, using current date");
}
```
### Support
Found a bug or need help? Open an issue on [GitHub]([url](https://github.com/aliajboy/MiladiToPersianConverter/issues/new)).

For quick questions, you can email: jebaleali@gmail.com

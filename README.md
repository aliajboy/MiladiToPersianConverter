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
- [API Reference](#api-reference)
- [Code Examples](#code-examples)
- [Contributing](#contributing)
- [License](#license)
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
```bash
Install-Package MiladiToPersianConverter
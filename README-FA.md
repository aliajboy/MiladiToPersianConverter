# MiladiToPersianConverter

![NuGet](https://img.shields.io/nuget/v/MiladiToPersianConverter.svg)

یک کتابخانه جامع و سبک NET. برای تبدیل تاریخ بین تقویم میلادی (گرگوری) و شمسی (جلالی) با امکانات گسترده فرمت‌بندی

## فهرست مطالب
- [ویژگی‌ها](#features)
- [نصب](#installation)
- [طریقه استفاده](#usage)
  - [تبدیل های پایه](#basic-conversion)
  - [فرمت های متنوع](#formatting-helpers)
  - [تبدیل شمسی به میلادی](#reverse-conversion)
  - [ابزار های کمکی](#utility-methods)
- [مثال ها](#code-examples)
- [پشتیبانی](#support)

## امکانات

- ⏳ تبدیل دوطرفه بین تقویم‌های میلادی و شمسی
- 🎨 گزینه‌های متعدد فرمت‌بندی:
  - رشته‌های فشرده تاریخ (YYYYMMDD)
  - تاریخ و زمان با ساعت و دقیقه (YYYYMMDDHHmm)
  - تاریخ و زمان کامل با ثانیه (YYYYMMDDHHmmss)
  - فرمت‌های خوانا با نام ماه‌های فارسی
- 🔧 متدهای کمکی برای:
  - افزودن جداکننده (خط تیره(-) یا اسلش(/)) به تاریخ‌ها
  - فرمت‌بندی زمان با (:)
  - دریافت نام روزها و ماه‌های فارسی مانند یک شنبه یا فروردین
  - تبدیل به زمان یونیکس
- 🛡️ مدیریت خطا با بازگشت به تاریخ جاری

## نصب

### NuGet Package Manager
```
Install-Package MiladiToPersianConverter
```

### Package Reference
```
<PackageReference Include="MiladiToPersianConverter" Version="1.0.0" />
```

## طریقه استفاده
### تبدیل های پایه
```
using MiladiToPersianConverter;

// Convert current date to Persian
DateTime now = DateTime.Now;
string persianDate = now.MiladiToPersian(); // "14020225"
string persianWithTime = now.MiladiToPersianWithMinutes(); // "140202251430"
string persianFull = now.MiladiToPersianWithSeconds(); // "14020225143015"
string withMonthName = now.MiladiToPersianWithMonthName(); // "25 اردیبهشت 1402"
```
### فرمت های متنوع
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
### تبدیل شمسی به میلادی
```
// Persian to Gregorian conversion
DateTime fromPersianDate = "14020225".PersianToMiladi();
DateTime fromPersianDateTime = "140202251430".PersianToMiladiDateTime();
```
### ابزار های کمکی
```
// Get Persian names
string dayName = DayOfWeek.Friday.GetPersianDayOfWeek(); // "جمعه"
string monthName = 7.GetPersianMounth(); // "مهر"

// Unix timestamp
double unixTime = DateTime.Now.ToUnixTimeStamp(3.5); // Tehran timezone
```
## مثال ها
### مثال کامل تبدیل
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
### مثال مدیریت خطا
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
### پشتیبانی

در صورت بروز مشکل یا نیاز به راهنمایی، یک issue جدید در گیتهاب باز کنید.

برای سوالات سریع می‌توانید ایمیل ارسال کنید: jebaleali@gmail.com

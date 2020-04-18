using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PerformanceCounterHelper;

namespace MvcMusicStore.PerformanceCounters
{
    [PerformanceCounterCategory
    ("MvcMusicStor",
        System.Diagnostics.PerformanceCounterCategoryType.MultiInstance,
        "MvcMusicStor")]
    public enum Counters
    {
        [PerformanceCounter
        ("Log in count",
            "Log in",
            System.Diagnostics.PerformanceCounterType.NumberOfItems32
        )]
        Logins,

        [PerformanceCounter
        ("Log out counts",
            "Log out",
        System.Diagnostics.PerformanceCounterType.NumberOfItems32
        )]
        Logouts,

        [PerformanceCounter
        ("Go to Home count",
            "Go to home",
            System.Diagnostics.PerformanceCounterType.NumberOfItems32
        )]
        GoToHome
    }
}
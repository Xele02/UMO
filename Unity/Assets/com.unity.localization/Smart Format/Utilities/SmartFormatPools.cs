using System;
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Core.Formatting;
using UnityEngine.Localization.SmartFormat.Core.Output;
using UnityEngine.Localization.SmartFormat.Core.Parsing;
using UnityEngine.Localization.SmartFormat.Core.Settings;
using UnityEngine.Pool;
using static UnityEngine.Localization.SmartFormat.Core.Parsing.Format;

namespace UnityEngine.Localization.SmartFormat
{
    static class FormatCachePool
    {
        internal static readonly ObjectPool<FormatCache> s_Pool = new ObjectPool<FormatCache>(() => new FormatCache(), null,
            fc =>
            {
                FormatItemPool.ReleaseFormat(fc.Format);
                fc.Format = null;
                //fc.Table = null;
                fc.CachedObjects.Clear();
                fc.VariableTriggers.Clear();
                fc.LocalVariables = null;
            });

        public static FormatCache Get(Format format)
        {
            var fc = s_Pool.Get();
            fc.Format = format;
            return fc;
        }

        public static PooledObject<FormatCache> Get(Format format, out FormatCache value)
        {
            var po = s_Pool.Get(out value);
            value.Format = format;
            return po;
        }

        public static void Release(FormatCache toRelease) => s_Pool.Release(toRelease);
    }

    static class FormatDetailsPool
    {
        internal static readonly ObjectPool<FormatDetails> s_Pool = new ObjectPool<FormatDetails>(() => new FormatDetails(), null, fd => fd.Clear());

        public static FormatDetails Get(SmartFormatter formatter, Format originalFormat, IList<object> originalArgs, FormatCache formatCache, IFormatProvider provider, IOutput output)
        {
            var fd = s_Pool.Get();
            fd.Init(formatter, originalFormat, originalArgs, formatCache, provider, output);
            return fd;
        }

        public static PooledObject<FormatDetails> Get(SmartFormatter formatter, Format originalFormat, object[] originalArgs, FormatCache formatCache, IFormatProvider provider, IOutput output, out FormatDetails value)
        {
            var po = s_Pool.Get(out value);
            value.Init(formatter, originalFormat, originalArgs, formatCache, provider, output);
            return po;
        }

        public static void Release(FormatDetails toRelease) => s_Pool.Release(toRelease);
    }

    static class FormatItemPool
    {
        internal static readonly ObjectPool<LiteralText> s_LiteralTextPool = new ObjectPool<LiteralText>(() => new LiteralText(), null, lt => lt.Clear());
        internal static readonly ObjectPool<Format> s_FormatPool = new ObjectPool<Format>(() => new Format(), null, f => f.ReleaseToPool());
        internal static readonly ObjectPool<Placeholder> s_PlaceholderPool = new ObjectPool<Placeholder>(() => new Placeholder(), null, p => p.ReleaseToPool());
        internal static readonly ObjectPool<Selector> s_SelectorPool = new ObjectPool<Selector>(() => new Selector(), null, s => s.Clear());

        public static LiteralText GetLiteralText(SmartSettings smartSettings, FormatItem parent, int startIndex)
        {
            var lt = s_LiteralTextPool.Get();
            lt.Init(smartSettings, parent, startIndex);
            return lt;
        }

        public static LiteralText GetLiteralText(SmartSettings smartSettings, FormatItem parent, int startIndex, int endIndex)
        {
            var lt = s_LiteralTextPool.Get();
            lt.Init(smartSettings, parent, startIndex, endIndex);
            return lt;
        }

        public static LiteralText GetLiteralText(SmartSettings smartSettings, FormatItem parent, string baseString, int startIndex, int endIndex)
        {
            var lt = s_LiteralTextPool.Get();
            lt.Init(smartSettings, parent, baseString, startIndex, endIndex);
            return lt;
        }

        public static Format GetFormat(SmartSettings smartSettings, string baseString)
        {
            var f = s_FormatPool.Get();
            f.Init(smartSettings, null, baseString, 0, baseString.Length);
            return f;
        }

        public static Format GetFormat(SmartSettings smartSettings, string baseString, int startIndex, int endIndex)
        {
            var f = s_FormatPool.Get();
            f.Init(smartSettings, null, baseString, startIndex, endIndex);
            return f;
        }

        public static Format GetFormat(SmartSettings smartSettings, string baseString, int startIndex, int endIndex, bool nested)
        {
            var f = s_FormatPool.Get();
            f.Init(smartSettings, null, baseString, startIndex, endIndex);
            f.HasNested = nested;
            return f;
        }

        public static Format GetFormat(SmartSettings smartSettings, Placeholder parent, int startIndex)
        {
            var f = s_FormatPool.Get();
            f.Init(smartSettings, parent, startIndex);
            f.parent = parent;
            return f;
        }

        public static Placeholder GetPlaceholder(SmartSettings smartSettings, Format parent, int startIndex, int nestedDepth)
        {
            var p = s_PlaceholderPool.Get();
            p.Init(smartSettings, parent, startIndex);
            p.NestedDepth = nestedDepth;
            p.FormatterName = "";
            p.FormatterOptions = "";
            return p;
        }

        public static Placeholder GetPlaceholder(SmartSettings smartSettings, Format parent, int startIndex, int nestedDepth, Format itemFormat, int endIndex)
        {
            var p = s_PlaceholderPool.Get();
            p.Init(smartSettings, parent, startIndex, endIndex);
            p.Format = itemFormat;
            p.NestedDepth = nestedDepth;
            p.FormatterName = "";
            p.FormatterOptions = "";
            return p;
        }

        public static Selector GetSelector(SmartSettings smartSettings, FormatItem parent, string baseString, int startIndex, int endIndex, int operatorStart, int selectorIndex)
        {
            var s = s_SelectorPool.Get();
            s.Init(smartSettings, parent, baseString, startIndex, endIndex);
            s.operatorStart = operatorStart;
            s.SelectorIndex = selectorIndex;
            return s;
        }

        public static void ReleaseLiteralText(LiteralText literal) => s_LiteralTextPool.Release(literal);
        public static void ReleaseFormat(Format format) => s_FormatPool.Release(format);
        public static void ReleasePlaceholder(Placeholder placeholder) => s_PlaceholderPool.Release(placeholder);
        public static void ReleaseSelector(Selector selector) => s_SelectorPool.Release(selector);

        public static void Release(FormatItem format)
        {
            switch (format)
            {
                case LiteralText lt:
                    ReleaseLiteralText(lt);
                    break;

                case Format f:
                    ReleaseFormat(f);
                    break;

                case Placeholder p:
                    ReleasePlaceholder(p);
                    break;

                case Selector s:
                    ReleaseSelector(s);
                    break;

                default:
                    Debug.LogError("Unhandled type " + format.GetType());
                    break;
            }
        }
    }

    static class FormattingInfoPool
    {
        internal static readonly ObjectPool<FormattingInfo> s_Pool = new ObjectPool<FormattingInfo>(() => new FormattingInfo(), null, fi => fi.ReleaseToPool());

        public static FormattingInfo Get(FormatDetails formatDetails, Format format, object currentValue)
        {
            var fi = s_Pool.Get();
            fi.Init(formatDetails, format, currentValue);
            return fi;
        }

        public static FormattingInfo Get(FormattingInfo parent, FormatDetails formatDetails, Format format, object currentValue)
        {
            var fi = s_Pool.Get();
            fi.Init(parent, formatDetails, format, currentValue);
            return fi;
        }

        public static FormattingInfo Get(FormattingInfo parent, FormatDetails formatDetails, Placeholder placeholder, object currentValue)
        {
            var fi = s_Pool.Get();
            fi.Init(parent, formatDetails, placeholder, currentValue);
            return fi;
        }

        public static void Release(FormattingInfo toRelease) => s_Pool.Release(toRelease);
    }

    static class ParsingErrorsPool
    {
        internal static readonly ObjectPool<ParsingErrors> s_Pool = new ObjectPool<ParsingErrors>(() => new ParsingErrors(), null, pe => pe.Clear());

        public static ParsingErrors Get(Format format)
        {
            var pe = s_Pool.Get();
            pe.Init(format);
            return pe;
        }

        public static void Release(ParsingErrors toRelease) => s_Pool.Release(toRelease);
    }

    static class SplitListPool
    {
        internal static readonly ObjectPool<SplitList> s_Pool = new ObjectPool<SplitList>(() => new SplitList(), null, sl => sl.Clear());

        public static SplitList Get(Format format, List<int> splits)
        {
            var sl = s_Pool.Get();
            sl.Init(format, splits);
            return sl;
        }

        public static void Release(SplitList toRelease) => s_Pool.Release(toRelease);
    }

    static class StringOutputPool
    {
        internal static readonly ObjectPool<StringOutput> s_Pool = new ObjectPool<StringOutput>(() => new StringOutput(), null, so => so.Clear());

        public static StringOutput Get(int capacity)
        {
            var so = s_Pool.Get();
            so.SetCapacity(capacity);
            return so;
        }

        public static PooledObject<StringOutput> Get(int capacity, out StringOutput value)
        {
            var po = s_Pool.Get(out value);
            value.SetCapacity(capacity);
            return po;
        }

        public static void Release(StringOutput toRelease) => s_Pool.Release(toRelease);
    }
}

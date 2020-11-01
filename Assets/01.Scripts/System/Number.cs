using System.Collections.Generic;
using System.Text;
using System.Linq;

public static class Number {
    private static readonly List<char> Digits = new List<char>() {'만', '억', '조', '경'};

    private static StringBuilder builder;
    private static Queue<char> queue;

    private static StringBuilder Builder => builder ??= new StringBuilder();
    private static Queue<char> Queue => queue ??= new Queue<char>();

    public static string ToKorean(this ulong number) {
        Builder.Clear();
        Queue.Clear();
        var digit = 0;

        foreach (var ch in number.ToString().Reverse()) {
            Queue.Enqueue(ch);
            if (Queue.Count < 5) {
                continue;
            }

            while (Queue.Count != 1) {
                Builder.Insert(0, Queue.Dequeue());
            }

            Builder.Insert(0, Digits[digit]);
            digit++;
        }

        while (Queue.Count != 0) {
            Builder.Insert(0, Queue.Dequeue());
        }

        return Builder.ToString();
    }

    public static string ToKorean(this uint number) {
        return ToKorean((ulong)number);
    }

    public static string ToSimpleKorean(this ulong number) {
        var korean = number.ToKorean();
        if (!korean.Contains("0000")) {
            return korean;
        }

        Builder.Clear();
        Builder.Append(korean);
        Builder.Replace("0000", string.Empty);
        var isPreviousLetter = false;

        for (var i = 1; i < Builder.Length; i++) {
            var isLetter = char.IsLetter(Builder[i]);
            if (isLetter && isPreviousLetter) {
                Builder.Remove(i, 1);
                i--;
            }
            else {
                isPreviousLetter = isLetter;
            }
        }

        return Builder.ToString();
    }

    public static string ToSimpleKorean(this uint number) {
        return ToSimpleKorean((ulong)number);
    }
}
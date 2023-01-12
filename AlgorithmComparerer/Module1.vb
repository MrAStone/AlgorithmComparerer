Module Module1

    Sub Main()

        Dim sw As New Stopwatch
        Dim numVals As Integer
        Dim n As New Random
        Do
            sw.Reset()
            Console.Write("Enter the number of values: ")
            numVals = Console.ReadLine
            Dim nums(numVals) As Integer
            For i = 0 To numVals
                nums(i) = n.Next(1, Integer.MaxValue)
            Next
            sw.Start()

            MergeSortRecursive(nums, 0, numVals) ' sort the array nums, starting from index 0
            ' and ending at index numVals (The last index of the array)
            sw.Stop()
            Console.WriteLine("It took " & sw.ElapsedMilliseconds & " miliseconds to sort (merge)")
            sw.Reset()
            For i = 0 To numVals
                nums(i) = n.Next(1, Integer.MaxValue)
            Next
            sw.Start()
            BubbleSort(nums)
            sw.Stop()
            Console.WriteLine("It took " & sw.ElapsedMilliseconds & " miliseconds to sort (bubble)")
        Loop



    End Sub
    Sub BubbleSort(a As Integer())
        Dim n = a.Length
        Dim swaps As Boolean = False
        Do
            swaps = False
            For i = 1 To n - 1
                If a(i) < a(i - 1) Then
                    Dim temp = a(i)
                    a(i) = a(i - 1)
                    a(i - 1) = temp
                    swaps = True
                End If
            Next
            n -= 1
        Loop Until Not swaps
    End Sub
    Sub MergeSortRecursive(ByRef a As Integer(), low As Integer, high As Integer)
        If low < high Then
            Dim m As Integer = low + (high - low) \ 2
            MergeSortRecursive(a, low, m)
            MergeSortRecursive(a, m + 1, high)
            Merge(a, low, m, high)
        End If
    End Sub

    Sub Merge(ByRef a As Integer(), low As Integer, mid As Integer, high As Integer)
        Dim i As Integer, j As Integer, k As Integer
        Dim num1 As Integer = mid - low + 1
        Dim num2 As Integer = high - mid

        Dim L(num1 - 1) As Integer
        Dim R(num2 - 1) As Integer
        For i = 0 To num1 - 1
            L(i) = a(low + i)
        Next

        For j = 0 To num2 - 1
            R(j) = a(mid + 1 + j)
        Next

        i = 0
        j = 0
        k = low

        While i < num1 And j < num2
            If L(i) <= R(j) Then
                a(k) = L(i)
                i += 1
            Else
                a(k) = R(j)
                j += 1
            End If

            k += 1
        End While

        While i < num1
            a(k) = L(i)
            i += 1
            k += 1
        End While

        While j < num2
            a(k) = R(j)
            j += 1
            k += 1
        End While
    End Sub
End Module

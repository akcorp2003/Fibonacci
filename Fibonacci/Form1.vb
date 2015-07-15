Imports System.Collections

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myqueue As New Queue(Of Integer)
        ClearList()
        myqueue = GetFibonacciTerms(Convert.ToInt32(NumTerms.Text))
        FillinList(myqueue)

    End Sub

    Public Function GetFibonacciTerms(ByVal num_terms As Integer) As Queue(Of Integer)
        Dim first_term As Integer = 0
        Dim second_term As Integer = 1

        Dim fib_queue As New Queue(Of Integer)
        fib_queue.Enqueue(first_term)
        fib_queue.Enqueue(second_term)

        Dim total_terms As Integer = num_terms - 2
        For i As Integer = 0 To total_terms - 1 Step 1
            Dim curr_term As Integer = first_term + second_term
            fib_queue.Enqueue(curr_term)
            first_term = second_term
            second_term = curr_term
        Next

        Return fib_queue
    End Function

    Public Sub FillinList(ByVal listofterms As Queue(Of Integer))
        Dim val As ListViewItem
        For i As Integer = 0 To listofterms.Count - 1 Step 1
            val = ListView1.Items.Add(Convert.ToString(i))
            val.SubItems.Add(listofterms.Dequeue())
            ListView1.Update()
            ListView1.EndUpdate()
        Next
    End Sub

    Public Sub ClearList()
        Dim listitem As ListViewItem
        If ListView1.Items.Count = 0 Then
            Return
        End If
        For i = ListView1.Items.Count - 1 To 0 Step -1
            listitem = ListView1.Items(i)
            ListView1.Items.Remove(listitem)
        Next
    End Sub
End Class

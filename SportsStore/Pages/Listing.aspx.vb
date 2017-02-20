Public Class Listing
    Inherits System.Web.UI.Page
    Private repo As New Repository()
    Private pageSize As Integer = 4
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub PreviousButtonOnClick(sender As Object, e As EventArgs)

        Dim current = CurrentPage - 1

        If (current - 1 >= 1) Then
            Response.Redirect("/Pages/Listing.aspx?Page=" + CStr(current))
        Else
            Response.Redirect("/Pages/Listing.aspx?Page=1")
        End If

    End Sub

    Protected Sub NextButtonOnClick(sender As Object, e As EventArgs)

        Dim maxPg = MaxPage
        Dim nextPg = CurrentPage + 1

        If (nextPg <= maxPg) Then
            Response.Redirect("/Pages/Listing.aspx?Page=" + CStr(nextPg))
        Else
            Response.Redirect("/Pages/Listing.aspx?Page=" + CStr(maxPg))
        End If

    End Sub

    Protected Sub CheckoutButtonOnClick(sender As Object, e As EventArgs)

        Response.Redirect("/Pages/CartView.aspx")
    End Sub

    Public Function GetProducts() As IEnumerable(Of Product)
        Dim products As IEnumerable(Of Product) = FilterProducts()
        Return FilterProducts().OrderBy(Function(p) p.Name).Skip((CurrentPage - 1) * pageSize).Take(pageSize)
    End Function

    Protected ReadOnly Property CurrentPage() As Integer
        Get
            Dim page As Integer
            page = If(Integer.TryParse(Request.QueryString("page"), page), page, 1)
            Return If(page > MaxPage, MaxPage, page)
        End Get
    End Property

    Protected ReadOnly Property MaxPage() As Integer
        Get
            Return CInt(Math.Ceiling(CDec(repo.Products.Count()) / pageSize))
        End Get
    End Property

    Private Function FilterProducts() As IEnumerable(Of Product)
        Dim products As IEnumerable(Of Product) = repo.Products
        Dim currentCategory As String = If(DirectCast(RouteData.Values("category"), String), Request.QueryString("category"))
        Return If(currentCategory Is Nothing, products,products.Where(Function(p) p.Category = currentCategory))
    End Function
End Class
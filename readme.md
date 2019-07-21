<!DOCTYPE html>
<html>
<head>
    <b>API Doc</b><br>
</head>
<body>
    <table>
        <tr>
            <th>API</th>
            <th>Description</th>
            <th>Request Body</th>
            <th>Response Body</th>
        </tr>
        <tr>
            <td>GET /api/carts</td>
            <td>Get all cart items <br> with total amount</td>
            <td>none</td>
            <td>Array of cart items and <br> total amount variable (200 Ok)</td>
        </tr>
        <tr>
            <td>POST /api/carts</td>
            <td>Add product to <br>shopping cart</td>
            <td>
                {"productId": id(int)}
            </td>
            <td>Array of cart items and <br>total amount variable (201 Created)</td>
        </tr>        
    </table>
</body>

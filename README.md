# N1_11
1, Quy trình mô hình hoá dịch vụ REST:

![Picture1](https://user-images.githubusercontent.com/101632970/228396217-3aeaf935-59cc-42eb-902b-5073ff2f70e0.png)

 
1,Phân tách quy trình thành các hành động chi tiết:
-	Quy trình “Đặt vé xem phim” được chia ra thành các hành động chi tiết sau:
o	Bắt đầu quy trình đặt vé
o	Khách hàng chọn phim, suất chiếu, số ghế theo nhu cầu
o	Xác định xem sự kiện có hợp lệ hay không?
o	Nếu sự kiện không hợp lệ (VD: ghế đã được đặt,…) thì quay lại bước 2
o	Xác định xem khách hàng có xác nhận hành động đặt vé và thanh toán không?
o	Nếu khách hàng từ chối xác nhận thì kết thúc chương trình
o	Xác minh từ chối thủ công
o	Gửi email chứa mã vé về email khách hàng đăng ký
o	Xác nhận chấp nhận thủ công
o	Cập nhật lại dữ liệu trong cơ sở dữ liệu
o	Kết thúc quy trình

2,Lọc bỏ các hành động không phù hợp:
-	Quy trình “Đặt vé xem phim” được chia ra thành các hành động chi tiết sau:
o	Bắt đầu quy trình đặt vé
o	Khách hàng chọn phim, suất chiếu, số ghế theo nhu cầu
o	Xác định xem sự kiện có hợp lệ hay không?
o	Nếu sự kiện không hợp lệ (VD: ghế đã được đặt,…) thì quay lại bước 2
o	Xác định xem khách hàng có xác nhận hành động đặt vé và thanh toán không?
o	Nếu khách hàng từ chối xác nhận thì kết thúc chương trình
o	Xác minh từ chối thủ công
o	Gửi email chứa mã vé về email khách hàng đăng ký
o	Xác nhận chấp nhận thủ công
o	Cập nhật lại dữ liệu trong cơ sở dữ liệu
o	Kết thúc quy trình

3,Thành phần dịch vụ Đặt vé xem phim
 ![Picture2](https://user-images.githubusercontent.com/101632970/228396255-a7a697c9-c32c-49fd-8a1f-a122700b8db9.png)


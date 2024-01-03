
# HOME DECOR

Lập trình game casual thể loại match 3 kết hợp trang trí nhà.

**Thành viên nhóm:**  
Lê Đình Nam (Trưởng nhóm)  
Nguyễn Thế Mạnh  
Lương Mai Quỳnh  
Nguyễn Trần Quang Mạnh  
Vũ Văn Trí  
# 1. Mô tả game
Tựa game home decorator (trang trí nhà cửa) kết hợp với game match 3. Trang trí căn nhà gồm có nhiều phòng, mỗi phòng có nhiều đồ vật. Để trang trí đồ vật mới vào nhà, người chơi cần có số sao (tương tự như tiền) tương ứng để đổi lấy đồ vật trang trí phòng. Mỗi đồ vật trang trí sẽ có 3 loại. Người chơi có thể thay đổi loại 
của đồ vật mà không mất sao. Người chơi có thể kiếm thêm sao bằng cách chơi game match 3 (tương tự game candy crush) với mỗi màn tương ứng hoàn thành sẽ được 1 sao. Đồ vật trang trí trong nhà thường là 1 - 2 sao. Độ khó của các màn chơi match 3 là khác nhau. Sẽ có một số phần thưởng thêm cho game match 3 như số mạng chơi vô hạn (mặc định là 5), etc.

## 1.1. Các màn hình chính của game
**Màn hình chính trang trí căn phòng**
![image](https://github.com/lnam1602/se5.1/assets/148826929/12c31e18-bca2-4695-83fe-ae18cb8e5f78)

**Màn hình cài đặt trong trang trí phòng**
![image](https://github.com/lnam1602/se5.1/assets/148826929/5a66b438-ea65-455e-b8f3-5f39741cae5e)

**Màn hình tùy chọn căn phòng để trang trí trong nhà**
![image](https://github.com/lnam1602/se5.1/assets/148826929/3a66c08e-0b1e-4313-9c36-89f24e8c0427)

**Màn hình game match 3**
![image](https://github.com/lnam1602/se5.1/assets/148826929/6566173f-3113-4654-abf9-3c2fc403b385)


## 1.2. Các usecase trong game
**Game Home Decor**
Khi mới vào game, người chơi sẽ nhìn thấy màn hình game trang trí phòng là Veranda, Bedroom, Girls Bedroom, Attic Room, LivingRoom, Kitchen Country.
Người chơi sẽ được tặng một số sao nhất định khi vào game
Để trang trí nhà, người chơi sẽ bấm vào dấu "+", tại đây sẽ hiện ra tên đồ vật để trang trí và số sao yêu cầu để trang trí
![image](https://github.com/lnam1602/se5.1/assets/148826929/76abcff1-fe68-4567-87b4-281d0e17e735)
Người chơi bấm giữ ngôi sao kéo vào và thả, tại đây sẽ có 3 lựa chọn cho đồ vật. Người chơi có thể tùy chọn 1 trong 3 mẫu đồ vật đấy
![image](https://github.com/lnam1602/se5.1/assets/148826929/03dfc2b4-cc4a-4e3c-9683-978e4ad75e4d)
Sẽ có một số thứ tự ưu tiên để trang trí các đồ vật trong game mà hệ thống mặc định để đảm bảo tính hợp lý của game. Ví dụ: Muốn thêm giường và đệm vào căn phòng, ta phải thêm giường vào trước rồi mới đến đệm, chứ không thể thêm đệm vào trước rồi mới thêm giường. Như vậy, khi người chơi trang trí giường xong thì game mới hiển thị nút trang trí đệm.

Sau khi thêm đồ vật, số sao của người chơi bị giảm đi sẽ tương ứng với số sao cần để thêm đồ vật.
Khi người chơi cần thêm sao để trang trí nhà, sẽ có các màn chơi game match 3 để nhận thêm sao.

**Game Match 3**
Game match 3 là tựa game có màn chơi là một ma trận các viên kẹo được sắp xếp theo thứ tự ngẫu nhiên. Nhiệm vụ của người chơi là từ ma trận đấy để thay đổi vị trí của 2 viên kẹo cạnh nhau để tạo ra một chuổi gồm 3 hoặc nhiều hơn các viên kẹo cùng loại. Khi có những chuỗi kẹo như thể thì sẽ tự động tính điểm và chuỗi kẹo đó biến mất khỏi ma trận.

Khi có 4 viên kẹo match nhau sẽ được 1 quả pháo, 5 viên match nhau sẽ được đĩa bay, 2x2 viên match nhau sẽ được tên lửa, hình chữ L hoặc T sẽ được quả bom với tác dụng của mỗi loại này khác nhau.
![image](https://github.com/lnam1602/se5.1/assets/148826929/c5aa2780-4eaa-41c4-8482-c58b0e6debba)
Khi bấm vào "Play", trò chơi sẽ hiển thị game match 3 như sau
![image](https://github.com/lnam1602/se5.1/assets/148826929/74646d9f-497c-4314-ab40-66b96172c573)
Ở đây, trong block bên trái, số 27 thể hiện cho màn chơi hiện tại. Ở trong block sẽ hiển thị các mục tiêu mà người chơi cần phải thực hiện để hoàn thành màn chơi. Trong ví dụ này người chơi sẽ cần phải phá 60 con gấu trắng và 46 viên chocolate để hoàn thành màn chơi với 29 lượt đổi vị trí các viên kẹo. Điều này được thể hiện bằng một ô có ghi số 29 ở phía dưới block.

Trong khi chơi game, người chơi nếu gặp khó khăn trong màn chơi thì có thể sử dụng một số công cụ có sẵn ở bên phải màn hình chơi game tùy theo số lượng được hiển thị bên cạnh của từng công cụ. Ở đây cái búa nhỏ ghi số 2 nghĩa là người chơi có thể sử dụng búa 2 lần để phá viên kẹo khỏi ma trận.

![image](https://github.com/lnam1602/se5.1/assets/148826929/9918a33f-023c-45a5-83b9-a4b01a93978f)
Khi người chơi đã hết lượt đổi vị trí mà vẫn chưa hoàn thành màn chơi, game sẽ tự động đưa là offer là đổi 1000 xu để lấy 5 lượt đổi và 1 quả tên lửa. Người chơi có thể nhận thêm xu bằng cách hoàn thành màn chơi hoặc dùng tiền thật để mua. Để mua xu bằng tiền, người chơi có thể bấm dấu "+" ở bên cạnh ô hiển thị xu.
![image](https://github.com/lnam1602/se5.1/assets/148826929/d7b8c48c-96ef-4b1c-8779-02fd2532a3ab)
Khi bấm vào, game sẽ hiển thị lân một màn hình với nhiều lựa chọn cho người chơi để mua số lượng xu tùy theo ý muốn của người chơi.
![image](https://github.com/lnam1602/se5.1/assets/148826929/cb71623e-08d7-4024-8ea2-63348d676b55)
![image](https://github.com/lnam1602/se5.1/assets/148826929/75c901fa-2813-4a2e-9f60-f52d9b5d38cb)
Số lượt chơi match 3 trong 1 thời gian nhất định sẽ phụ thuộc vào số tim còn lại ở trên góc trái của game trang trí nhà
![image](https://github.com/lnam1602/se5.1/assets/148826929/3ee36bcb-7f1a-455c-8336-22c4ea1acaeb)
Khi số tim nhỏ hơn 5, người chơi sẽ phải dừng chơi match 3 một thời gian để đợi reset, hoạc người chơi cũng có thể mua bằng tiền để có thể chơi ngay lập tức. Số tim tối đa là 5. Khi đủ 5 tim thời gian sẽ không đếm mà thay vào đó là chữ "Full"








# 2. Các sửa đổi cho game
Mô tả chi tiết các sửa đổi trong game, bao gồm hình ảnh, thuyết minh, thuật toán hoặc các Class hay method thêm/sửa/xóa
## 2.1. Thay đổi 1
**Thêm chức năng Replay: Xem lại quá trình trang trí từng đồ vật trong 1 căn phòng**
## 2.2. Thay đổi 2
**Thêm một số tính năng có sẵn trong dự án như: âm thanh, điểm danh theo ngày, etc.**

Màn hình Setting
![image](https://github.com/lnam1602/se5.1/assets/148826929/2904ba63-9248-4dd8-a020-32e90cbf6a38)

Điểm danh hằng ngày nhận quà
![image](https://github.com/lnam1602/se5.1/assets/148826929/8d919564-73da-423e-a894-46eedc799226)

Màn hình thông báo login
![image](https://github.com/lnam1602/se5.1/assets/148826929/b9ff6020-ad6f-4445-adc6-3cac12418981)



# 3. Hướng dẫn Khởi tạo dự án
## 3.1. Cài Unity bản từ 2022 trở đi
Đăng ký tài khoản Unity bằng account sinh viên để có thể tham gia chương trình Education License của Unity

## 3.2. Mở dự án trên Unity và chạy thử ngay trên Màn hình Unity Editor
Vào menu File-> Open Scene, chọn vào file Assets\GameBase\DesignHomeDemo\Scenes\SplashScene.unity
Bấm nút Play của Unity để chạy thử

## 3.3. Build và chạy trên Android

Vào menu File -> Build Settings, chọn Platform là Android rồi nhấn "Switch Platform" để chuyển sang Android. Sau đó nhấn vào nút Build để thực hiện build ra file APK. Tham khảo trên Google search để biết cách cài đặt Build settings sao cho phù hợp

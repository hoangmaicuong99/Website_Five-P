function CheckPost()
{
    let titlePost = document.getElementById("titlePost").value;
    let contentPost = document.getElementById("contentPost").value;
    let technologyPost = document.getElementById("addTechnologys").value;
    let showCheckPost = document.getElementById("showCheckPost");
    if (titlePost == '' || contentPost == '' || technologyPost == '') {
        showCheckPost.innerHTML = "Tiêu đề, nội dung hoặc công nghệ không được để trống!";
    }
    else if (titlePost.length < 20 || contentPost.length < 30) {
        showCheckPost.innerHTML = "Tiêu đề hoặc nội dung không được dưới 20 ký tự!";
    }
    else {
        return true;
    }
    return false;
}
function GuideTitle() {
    document.getElementById("showGuide").innerHTML = '<i class='+'"fas fa-directions"'+' style='+'"color: orangered;font-size:30px"'+'></i> Tiêu đề bạn nên ghi ngắn gọn, ghi những ý chính và công nghệ liên quan đến bài viết, để mọi người có thể dễ dàng tìm thấy bài của bạn hơn. Tiêu đề phải trên 20 ký tự!';
}
function GuideContentPost() {
    document.getElementById("showGuide").innerHTML = '<i class='+'"fas fa-directions"'+' style='+'"color: orangered;font-size:30px"'+'></i> Phần nội dung bạn nên ghi đầy đủ rỏ ràng (chi tiết) câu hỏi của bạn để mọi người có thể dễ dàng hiểu, nếu liên quan đến code nên đăng code rỏ ràng cho mọi người cùng tham khảo.';
}
function GuideTechnology() {
    document.getElementById("showGuide").innerHTML = '<i class='+'"fas fa-directions"'+' style='+'"color: orangered;font-size:30px"'+'></i> Chọn công nghệ liên quan đến bài viết để mọi người có thể dễ dàng tìm thấy câu hỏi của bạn đúng với công nghệ của người đó.';
}
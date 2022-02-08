var allDeleteBtns = document.querySelectorAll(".delete-btn");

for (var i = 0; i < allDeleteBtns.length; i++) {

    allDeleteBtns[i].onclick = (e) => {
        let result = confirm("Do you want to remove?");
        if (!result)
            e.preventDefault();
    };
}
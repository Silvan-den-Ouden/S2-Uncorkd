function kebabTrigger(wine_id, review_id) {
    let action = prompt("Delete/Edit/View wine");

    if (action === null || action === '') {
        alert("Cancelled action.")
    } else if (action.toLowerCase() === "edit") {
        location.href = "/Review/Update?id=" + review_id;
    } else if (action.toLowerCase() === "delete") {
        if (confirm("Are you sure you want to delete this review?")) {
            deleteReview(review_id);
            alert("Deleted review succesfully, refreshing page.")
        } else {
            alert("Deletion cancelled.")
        }
    } else if (action.toLowerCase() === "view wine") {
        location.href = "/Wine?id=" + wine_id;
    }
}

function deleteReview(review_id) {
    $.ajax({
        url: '/Review/DeleteReview',
        type: 'GET',
        data: { reviewId: review_id },
        success: function (data) {
            console.log(data);
            location.href = '';
        },
        error: function (error) {
            console.log("error", error);
        }
    });
}
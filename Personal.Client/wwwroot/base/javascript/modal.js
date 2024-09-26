function OpenModal(modalId) {
    var myModal = new bootstrap.Modal(document.getElementById(modalId))
    myModal.show()
}
function CloseModal(modalId) {
    var myModalEl = document.getElementById(modalId)
    var modal = bootstrap.Modal.getInstance(myModalEl) 
    modal.hide();
}

var addNoteButton = document.getElementById("addNoteButton");
var addNoteForm = document.getElementById("addNoteForm");
var cancelAddNoteButton = document.getElementById("cancelAddNoteButton");
var addNoteConfirmButton = document.getElementById("addNoteConfirmButton");
var titleNoteAdd = document.getElementById("titleNoteAdd");
var textNoteAdd = document.getElementById("textNoteAdd");
var notes = document.getElementById("notes");
var replaceNoteForm = document.getElementById("replaceNoteForm");
var titleNoteReplace = document.getElementById("titleNoteReplace");
var textNoteReplace = document.getElementById("textNoteReplace");
var replaceNoteConfirmButton = document.getElementById("replaceNoteConfirmButton");
var cancelReplaceNoteButton = document.getElementById("cancelReplaceNoteButton");
var modal = document.getElementById("modal");
var replacedNote;

addNoteButton.addEventListener("click", showAddForm, false);
cancelAddNoteButton.addEventListener("click", hideAddForm, false);
cancelReplaceNoteButton.addEventListener("click", hideReplaceForm, false);
addNoteConfirmButton.addEventListener("click", addNote, false);

function showAddForm()
{
    modal.style = "display:block;";
    addNoteForm.style = "display:block;";
    titleNoteAdd.value = "";
    textNoteAdd.value = "";
}

function hideAddForm()
{
    modal.style = "display:none;";
    addNoteForm.style = "display:none;";
    isDeletingNote = false;
}

function addNote()
{
    storage.add(textNoteAdd.value, titleNoteAdd.value);
    hideAddForm();
    updateNotes();
}

function updateNotes()
{
    while(notes.firstChild)
        notes.removeChild(notes.firstChild);
    for(var key of storage.getKeys)
    {
        isDeletingNote = false;
        var note = document.createElement("div");
        note.className = "note";

        var titleNoteAdd = document.createElement("span");
        titleNoteAdd.className = "title";
        titleNoteAdd.innerText = key;

        var textNoteAdd = document.createElement("span");
        textNoteAdd.className = "text";
        textNoteAdd.innerText = storage.getById(key);

        var deleteButton = document.createElement("img");
        deleteButton.className = "delete";
        deleteButton.src = "images/trash.png";
        deleteButton.addEventListener("click", deleteNote, false);

        note.appendChild(titleNoteAdd);
        note.appendChild(textNoteAdd);
        note.appendChild(deleteButton);
        note.addEventListener("click", showReplaceForm, false);

        notes.appendChild(note);
    }
}

function deleteNote()
{
    this.parentNode.removeEventListener("click", showReplaceForm, false);
    var confirmDeleting = confirm("Подтвердите удаление");
    if(confirmDeleting)
    {
        notes.removeChild(this.parentNode);
        storage.deleteById(this.previousSibling.previousSibling.innerText);
    }
}

function showReplaceForm()
{
    modal.style = "display:block";
    replaceNoteForm.style = "display: block";
    replaceNoteForm.children[0].value = this.children[0].innerText;
    replaceNoteForm.children[1].value = this.children[1].innerText;
    replaceNoteConfirmButton.addEventListener("click", replaceNote, false);
    replacedNote = this;
}

function hideReplaceForm()
{
    modal.style = "display:none;";
    replaceNoteForm.style = "display: none;";
    isDeletingNote = false;
}

function replaceNote()
{
    storage.deleteById(replacedNote.children[0].innerText);
    storage.add(this.parentNode.parentNode.children[1].value, this.parentNode.parentNode.children[0].value);
    updateNotes();
    hideReplaceForm();
}
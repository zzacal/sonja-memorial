// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Wow! Such vanilla!
const timeStamps = document.getElementsByClassName("message-created");
Array.from(timeStamps).forEach(e => {
  try {
    const timeAtt = e.getAttribute("time");  
    const date = new Date(timeAtt);  
    const localizedDate = date.toLocaleString();
    
    e.innerHTML = localizedDate;
  } catch (error) {
    console.log(error);
  }
});
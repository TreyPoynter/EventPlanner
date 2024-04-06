window.addEventListener('scroll', function () {
    const jumbotron = document.getElementById('jumbotron');
    const navbar = document.getElementById('navbar');

    if (window.scrollY > 0) { // Change transparency as soon as user starts scrolling
        navbar.classList.remove('transparent');
        navbar.classList.add('white-bg');
    } else {
        navbar.classList.remove('white-bg');
        navbar.classList.add('transparent');
    }
});
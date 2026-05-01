// Theme toggle logic (keep as is)
if (
    localStorage.theme === 'dark' ||
    (!('theme' in localStorage) &&
        window.matchMedia('(prefers-color-scheme: dark)').matches)
) {
    document.documentElement.classList.add('dark');
} else {
    document.documentElement.classList.remove('dark');
}

// Utility function for image preview
function handleImagePreview(inputId, imageId) {
    const input = document.getElementById(inputId);
    const image = document.getElementById(imageId);

    if (!input || !image) return; // safety check

    input.addEventListener('change', function () {
        if (this.files && this.files[0]) {
            const reader = new FileReader();

            reader.onload = function (event) {
                image.src = event.target.result;
                image.style.display = 'block';
            };

            reader.readAsDataURL(this.files[0]);
        }
    });
}

// Apply to all cases
handleImagePreview('addPostUrl', 'addPostImage');
handleImagePreview('createStatusUrl', 'createStatusImage');
handleImagePreview('createProductUrl', 'createProductImage');
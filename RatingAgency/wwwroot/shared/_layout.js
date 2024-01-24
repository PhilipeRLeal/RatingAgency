
const main = function () {
    $(document).ready(function () {
        $('a').on('click', function (el) {
            el.preventDefault();
            var element = $(this)[0];

            if (element.href) {
                window.location = element.href;
            }
            else {
                console.log(element.target)
            }

        })
    })

}

main();
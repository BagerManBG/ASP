window.onload = () => {
    window.url = url = new URL(window.location.href);

    const checkboxes = $('.product-search-values input.search-value');
    const searchbar = $('.product-search-values input.product-search-bar');
    const search_category = $('.product-search-values select.product-search-category');
    const submit = $('.product-search-values button.product-search-submit');

    url.searchParams.forEach((val, key) => {
        $(`.product-search-values input.search-value[name=${key}]`).prop('checked', true);
    });

    checkboxes.click(e => {
        $this = $(e.target)

        if ($this.prop('checked')) {
            url.searchParams.set($this.attr('id'), 'true');
        } else {
            url.searchParams.delete($this.attr('id'));
        }
    });

    submit.click(e => {
        $this = $(e.target)

        const search_text = searchbar.val();
        const category = search_category.val();

        console.log(category);

        if (search_text) {
            url.searchParams.set('search', search_text);
        } else {
            url.searchParams.delete('search');
        }

        if (category >= 0) {
            url.searchParams.set('category', category);
        } else {
            url.searchParams.delete('category');
        }

        window.location.href = url.href;
    });
};
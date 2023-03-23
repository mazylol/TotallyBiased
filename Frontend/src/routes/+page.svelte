<script lang="ts">
    let visible = false;

    let shorthand = '';
    let lastShorthand = '';

    function toggle() {
        visible = !visible;
    }

    function search() {
        if (shorthand == lastShorthand) {
            return;
        }

        const data = fetch(`http://localhost:5106/api/Movie?shorthand=${shorthand}`, {
           method: 'GET',
           headers: {
               'Content-Type': 'application/json'
           }
        });

        const obj = JSON.parse(data);



        lastShorthand = shorthand;
    }
</script>

<div class="flex flex-col items-center justify-center">
    <form on:submit|once={toggle} on:submit|preventDefault={search}>
        <input type="text" placeholder="Shorthand"
               class="text-md text-gray-base w-96 mr-3 py-5 px-4 h-2 border border-gray-200 rounded mb-2 mt-16 rounded-xl shadow-sm" required bind:value={shorthand}/>
        <button type="submit" class="bg-blue-500 text-white w-16 rounded-xl h-10 font-bold">Search</button>
    </form>
</div>

{#if visible}
    <div class="mx-auto w-64 bg-white rounded-xl shadow-xl">
        <p>coc</p>
    </div>
{/if}
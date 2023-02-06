<template>
    <section class="">

        <div v-if="OpenForm" class="mx-auto  px-4 py-4 sm:px-6 lg:px-8">
            <div class=" ">
                <div class="rounded-lg bg-white p-8 shadow-lg lg:col-span-3 lg:p-12">

                    <form @submit.prevent="SubmitForm" class="space-y-4">
                        <div>
                            <label class="sr-only">Name</label>
                            <input v-model="CreateUser.fio"
                                class="w-full rounded-lg border-2 border-gray-200 p-3 text-sm" placeholder="Name"
                                type="text" id="name" />
                        </div>

                        <div class="grid grid-cols-1 gap-4 sm:grid-cols-2">
                            <div>
                                <label class="sr-only" for="birthDay">Дата рождения</label>
                                <input v-model="CreateUser.birthDay"
                                    class="w-full rounded-lg border-2 border-gray-200 p-3 text-sm"
                                    placeholder="Email address" type="date" id="birthDay" />
                            </div>

                            <div>
                                <label class="sr-only" for="City">Город</label>
                                <input v-model="CreateUser.city"
                                    class="w-full rounded-lg border-2 border-gray-200 p-3 text-sm"
                                    placeholder="Phone Number" type="text" id="City" />
                            </div>
                        </div>
                        <div class="flex">
                            <div class="mr-2">
                                <input @click="CreateUser.isMale = true" id="disabled-radio-1" type="radio" value=""
                                    name="disabled-radio"
                                    class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                                <label for="disabled-radio-1"
                                    class="ml-2 text-sm font-medium text-gray-400 dark:text-gray-500">Мужской</label>
                            </div>
                            <div class="">
                                <input @click="CreateUser.isMale = false" id="disabled-radio-2" type="radio" value=""
                                    name="disabled-radio"
                                    class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                                <label for="disabled-radio-2"
                                    class="ml-2 text-sm font-medium text-gray-400 dark:text-gray-500">Женский</label>
                            </div>
                        </div>
                        <div>
                            <label class="sr-only" for="message">Message</label>
                            <input v-model="CreateUser.country"
                                class="w-full rounded-lg border-2    border-gray-200 p-3 text-sm" placeholder="Message"
                                id="message" />
                        </div>

                        <div class="mt-2">
                            <button type="submit"
                                class="inline-flex w-full items-start justify-start rounded-lg bg-black px-5 py-1    text-white sm:w-auto">
                                <span class="font-medium"> Создать </span>

                                <svg xmlns="http://www.w3.org/2000/svg" class="ml-3 h-5 w-5" fill="none"
                                    viewBox="0 0 24 24" stroke="currentColor">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                        d="M14 5l7 7m0 0l-7 7m7-7H3" />
                                </svg>
                            </button>
                        </div>
                    </form>


                </div>
            </div>
        </div>
        <div @click="OpenForm = !OpenForm"
            class="inline-block rounded border border-indigo-600 bg-indigo-600 px-12 py-3 my-5 text-sm font-medium text-white hover:bg-transparent hover:text-indigo-600 focus:outline-none focus:ring active:text-indigo-500">
            Добавить пользователя
        </div>
    </section>
</template>

<script>
export default {
    data() {
        return {
            OpenForm: false,
            CreateUser: {
                fio: "ФИО",
                birthDay: Date,
                country: "Страна",
                city: "Город",
                isMale: false,
            }
        }
    },
    methods: {

        async SubmitForm() {
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");

            var raw = JSON.stringify({
                'fio': this.CreateUser.fio,
                'birthDay': this.CreateUser.birthDay,
                'country': this.CreateUser.country,
                'city': this.CreateUser.city,
                'isMale': this.CreateUser.isMale,

            });
            console.log(raw)
            console.log(this.CreateUser)

            var requestOptions = {
                method: 'POST',
                body: raw,
                headers: myHeaders,
                redirect: 'follow'
            };
            var re = await fetch("https://localhost:7193/api/User/Create", requestOptions)
                .then(response => {
                    if (response.status >= 200 && response.status < 300)
                        this.$emit("UpdateData")
                    else {
                        console.log(response.errors)
                    }
                    response.json()
                }
                )
                .then(x => this.UserList = x)
                .catch(error => console.log('error', error.errors));

            console.log(re)
        }
    }
}
</script>

<style lang="scss" scoped>

</style>
<template>
    <div id="employee-form" style="width:50%">
        <form @submit.prevent="handleSubmit">
            <label>Employee Name</label>
            <input 
                ref="first"
                type="text"
                :class="{ 'has-error': submitting && isNameValid }"
                v-model="employee.name"
                @focus="clearStatus"
                @keypress="clearStatus" 
            />
            <label>Employee Designation</label>
            <input 
                type="text"
                v-model="employee.designation"
                @focus="clearStatus"
            />
            <label>Employee Mobile</label>
            <input 
                type="text"
                v-model="employee.mobile"
                @focus="clearStatus"
            />
            <label>Employee Address</label>
            <input 
                type="text"
                v-model="employee.address"
                @focus="clearStatus"
            />
            <p v-if="error && submitting" class="error-message">
                ❗Please fill out all required fields and valid email address
            </p>
            <p v-if="success" class="success-message">
                ✅ Employee successfully added
            </p>
            <button>Add Employee</button>
        </form>
    </div>
</template>

<script>
export default {
    name: 'employee-form',
    data() {
        return{
            submitting: false,
            error: false,
            success: false,
            employee: {
                name: '',
                mobile: '',
                address: '',
                designation: '',
            },
        }
    },
    methods: {
        handleSubmit() {
            this.submitting = true
            this.clearStatus()

            if(this.isNameValid || this.isEmailValid){
                this.error = true
                return
            }

            this.$emit('add:employee', this.employee)
            this.$refs.first.focus()
            this.employee = {
                name: '',
                mobile: '',
                address: '',
                designation: '',               
            }
            this.error = false
            this.success = true
            this.submitting = false
        },

        clearStatus() {
            this.success = false
            this.error = false
        },
    },
    computed: {
        isNameValid() {
            return this.employee.name === '';
        },        
    },
}
</script>

<style scoped>
    form {
        margin-bottom: 2rem;
    }

    [class*='-message'] {
        font-weight: 500;
    }

    .error-message {
        color:#d33c40;
    }

    .success-message {
        color: #32a95d;
    }
    label {
        display: inline-block;
        width: 40%;
        margin: 5px;
    }
</style>
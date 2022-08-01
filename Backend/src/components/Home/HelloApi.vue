<template>  
    <div id="container" style="height:auto">
        <div id="employee-details">
            <table style="width:100%">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Designation</th>
                        <th>Mobile</th>
                        <th>Address</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="employee in employees" :key="employee.id">
                        <td v-if="editing === employee.id">
                            <input type="text" v-model="employee.name" />
                        </td>
                        <td v-else>{{ employee.name }}</td>

                        <td v-if="editing === employee.id">
                            <input type="text" v-model="employee.designation" />
                        </td>
                        <td v-else>{{ employee.designation }}</td>
                        <td v-if="editing === employee.id">
                            <input type="text" v-model="employee.mobile" />
                        </td>
                        <td v-else>{{ employee.mobile }}</td>
                        <td v-if="editing === employee.id">
                            <input type="text" v-model="employee.address" />
                        </td>
                        <td v-else>{{ employee.address }}</td>

                        <td v-if="editing === employee.id">
                        <button @click="editEmployee(employee)">Save</button>
                        <button @click="cancelEdit(employee)" class="muted-button">Cancel</button>
                    </td>

                    <td v-else>
                        <button @click="editMode(employee)">Edit</button>
                        <button @click="deleteEmployee(employee)" class="delete-button">Delete</button>
                    </td> 

                    </tr>
                </tbody>
            </table>
        </div>

        <div style="height:50px"></div>

        <div id="employee-form"  style="margin-top:50px;width:350px">
            <form @submit.prevent="submit" :class="{ error:responseStatus, loading }">
                <div class="mb-3">
                    <label>Employee Name</label>
                    <v-input ref="first" v-model="name" :responseStatus="responseStatus" />
                </div>
                <div class="mb-3">
                    <label>Employee Designation</label>
                    <v-input v-model="designation" :responseStatus="responseStatus" />
                </div>
                <div class="mb-3">
                    <label>Employee Mobile</label>
                    <v-input v-model="mobile" :responseStatus="responseStatus" />
                </div>
                <div class="mb-3">
                    <label>Employee Address</label>
                    <v-input v-model="address" :responseStatus="responseStatus" />
                </div>
                <div class="mb-3">
                    <p v-if="error && submitting" class="error-message">
                        ❗Please fill out all required fields and valid email address
                    </p>
                    <p v-if="success" class="success-message">
                        ✅ Employee successfully added
                    </p>
                </div>
                <div class="mb-3">
                    <v-button type="submit" lg primary>Add Employee</v-button>
                </div>
            </form>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
    import { client, checkAuth } from '../../shared';
    import { EmployeeRequestDto, EmployeeResonseDto } from '../../shared/dtos';
    import { Routes, redirect } from '../../shared/router';


@Component
export class HelloApi extends Vue {
    @Prop() public employees: EmployeeResonseDto;
    public txtName: string = '';
    public result: string = '';
    public editing: string = '';

    public mounted() {
        this.GetData();
    }

    name = '';
    designation = '';
    mobile = '';
    address = '';   
    loading = false;
    responseStatus = null;
    submitting = false;
    error = false;
    success = false;

    async submit() {
        try {
            this.loading = true;
            this.responseStatus = null;

            const response = await client.post(new EmployeeRequestDto({
                Name: this.name,
                Address: this.address,
                Designation: this.designation,
                Mobile: this.mobile
            }));
            this.name = '';
            this.designation = '';
            this.mobile = '';
            this.address = '';
            this.error = false;
            this.success = true;
            this.submitting = false;
            this.GetData();


        } catch (e: any) {
            this.responseStatus = e.responseStatus || e;
        } finally {
            this.loading = false;
        }
    }
 

    public async GetData() {       
        const r = await client.get(new EmployeeRequestDto());
        console.log(r);
        console.log("Text");
        this.employees = r;
        console.log(this.employees);
        
    }

    public async editMode(employee: any) {
        this.editing = employee.id
    }
    public async cancelEdit(employee: any) {
        this.editing = '';
    }

    public async editEmployee(employee: any) {
        if (employee.name === '') return
        const response = await client.put(new EmployeeRequestDto({
            Id: employee.id,
             Name: employee.name,
            Address: employee.address,
            Designation: employee.designation,
            Mobile: employee.mobile
        }));           
        this.editing = '';
        this.GetData();   
    }


    public async deleteEmployee(employee: any) {
        const response = await client.delete(new EmployeeRequestDto({
            Id: employee.id,
            Name: employee.name,
            Address: employee.address,
            Designation: employee.designation,
            Mobile: employee.mobile
        }));
        this.editing = '';
        this.GetData();
    }
}
export default HelloApi;
</script>

<style>
    form {
        margin-bottom: 2rem;
    }

    [class*='-message'] {
        font-weight: 500;
    }

    .error-message {
        color: #d33c40;
    }

    .success-message {
        color: #32a95d;
    }

    #employee-details {
        width: 100%;
    }

    button {
        background: #41b883;
        border: 1px solid #41b883;
    }

    .delete-button {
        background: #d11a2a;
        border: 1px solid #d11a2a;
    }

    .small-container {
        max-width: 720px;
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: left;
        color: #2c3e50;
        margin-top: 10px;
        margin-left: 10px;
    }
    button {
        margin: 0 0.5rem 0 0;
    }

    input {
        margin: 0;
    }

    .empty-table {
        text-align: center;
    }
</style>

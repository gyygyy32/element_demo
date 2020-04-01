<template>
  <div id="app">
    <el-page-header @back="goBack" content="新建"></el-page-header>
    <div class="form-content">
      <el-form :model="updateForm" :rules="rules" ref="updateForm" class="demo-form">
        <el-form-item label="字段1" :label-width="'120px'" prop="field1">
          <el-input v-model="updateForm.field1" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="字段2" :label-width="'120px'" prop="field2">
          <el-input v-model="updateForm.field2" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="字段3" :label-width="'120px'" prop="field3">
          <el-input v-model="updateForm.field3" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button @click="updateDialogFormVisible = false">取 消</el-button>
          <el-button id="btn" type="primary" @click="add('updateForm')">确 定</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script>
import { updateData, getEditData, addData } from "../utils/request01";
export default {
  name: "Edit",
  data() {
    return {
      rules: {
        field1: [{ required: true, message: "请填字段1", trigger: "blur" }],
        field2: [{ required: true, message: "请填字段2", trigger: "blur" }],
        field3: [{ required: true, message: "请填字段3", trigger: "blur" }]
      },
      updateForm: {
        field1: "",
        field2: "",
        field3: ""
      }
    };
  },
  methods: {
    goBack() {
      this.$router.push({ path: "/" });
    },
    async add(formName) {
      if (!(await this.$refs[formName].validate())) {
        return;
      }
      let res = await addData({
        ...this.updateForm
      });
      this.$message.success("添加成功");
      this.$refs[formName].resetFields();
    }
  },
  mounted: function() {}
};
</script>

<style scoped>
.demo-form {
  width: 460px;
}
.form-content {
  display: flex;
  justify-content: center; /* 水平居中 */
  align-items: center; /* 垂直居中 */
}
.el-row {
  margin-bottom: 20px;
  &:last-child {
    margin-bottom: 0;
  }
}
</style>
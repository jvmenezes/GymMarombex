namespace GymMarombex.Models {
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;


  public class Login {
	[DisplayName("Login")]
	[Required(ErrorMessage = "Esse campo é obrigatório")]
	public string UserName { get; set; }

	[DataType(DataType.Password)]
	[Required(ErrorMessage = "Esse campo é obrigatório")]
	public string Password { get; set; }

	public string LoginErrorMessage { get; set; }

  }
}

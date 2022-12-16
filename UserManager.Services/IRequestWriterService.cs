using UserManager.Models;

namespace UserManager.Services;

public interface IRequestWriterService
{
    void WriteRequest(CreateUserModel userRequest);
}
